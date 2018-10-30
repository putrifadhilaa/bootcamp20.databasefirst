using Bootcamp20.DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp20.databasefirst
{
    public class program
    {
        static void Main(string[] args)
        {
            program call = new program();
            //call.insertSupplier();
            //call.updateSupplier();
            //call.deleteSupplier();
            //call.insertItem();
            call.penjualan();
            //call.retrievesell();
            Console.Read();
        }
        Supplier supplier = new Supplier();
        Item item = new Item();
        MyContext _context = new MyContext();
        sell sell = new sell();
        SellItem sellitem = new SellItem();


        public Supplier GetById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        //public Sell GetByIdSuplliers(int id)
        //{
        //    return _context.Suppliers.Find(id);
        //}

        #region supplier
        public void insertSupplier()
        {
            Console.Write("insert your supplier name : ");
            string name = Console.ReadLine();
            supplier.Name = name;
            supplier.CreateDate= DateTimeOffset.Now.LocalDateTime;
            try
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
                Console.Write(ex.StackTrace);
            }
        }
        #endregion supplier

        public void updateSupplier()
        {
            Console.Write("Masukkan Id Supplier : ");
            int id = Convert.ToInt16(Console.ReadLine());

            var supplier = GetById(id);
            if (supplier != null)
            {
                Console.Write("insert your supplier name : ");
                string name = Console.ReadLine();
                supplier.Name = name;
                supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                Console.Write("your id isn't registered yet");
            }
        }



        public void deleteSupplier()
        {
            Console.Write("Masukkan id : ");
            int id = Convert.ToInt16(Console.ReadLine());
            var supplier = GetById(id);
            if (supplier != null)
            {
                supplier.DeleteDate = DateTimeOffset.Now.LocalDateTime;
                supplier.IsDelete = true;
                _context.Entry(supplier).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                Console.Write("your id isn't registered yet");
            }
        }


        #region Item
        public void insertItem()
        {
            Console.Write("insert your supplier id : ");
            int supplier = Convert.ToInt16(Console.ReadLine());
            Console.Write("insert your item name : ");
            string name = Console.ReadLine();
            Console.Write("insert your item price : ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("insert your item stock : ");
            int stock = Convert.ToInt16(Console.ReadLine());
            var Supplier = GetById(supplier);
            item.Name = name;
            item.Price = price;
            item.Stock = stock;
            item.Supplier = Supplier;
            try
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }
    }
    #endregion Item

    public void penjualan()
        {
            sell.CreateDate = DateTimeOffset.Now.LocalDateTime;
            _context.Sells.Add(Sell);
            _context.SaveChanges();

            var get = _context.Sells.Max(x => x.Id); 
            Console.Write("Masukkan Jumlah Barang yang Di Beli : ");
            int jum = Convert.ToInt16(Console.ReadLine());
            for (int i = 1; i <= jum; i++)
            {
                Console.WriteLine("-----------------------------");
                Console.Write("Masukkan Item Id yang Di Beli : ");
                int Id = Convert.ToInt16(Console.ReadLine());
                Console.Write("Masukkan Jumlah Item : ");
                sellitem.Item_Id = Id;
                Console.WriteLine("-----------------------------");
                //foreach (var item in value.items.tolist())
                //{
                //    Console.Write(item.name + "\t ");
                //    Console.WriteLine(item.price);
                //}
                Console.WriteLine("-------------------------");
            }
            //sell.SellItems = listsell;
            //supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;

        }

    //public void retrievesell()
    //{
    //    var get = _context.sells.max(x => x.id);
    //    var retrieve = _context.sells.include("items").where(x => x.id == get).tolist();
    //    foreach (var value in retrieve)
    //    {
    //        console.writeline("-----------------------------");
    //        console.writeline("your transaction id \t : " + value.id);
    //        console.writeline("date \t \t \t : " + value.createdate);
    //        console.writeline("-----------------------------");
    //        foreach (var item in value.items.tolist())
    //        {
    //            console.write(item.name + "\t ");
    //            console.writeline(item.price);
    //        }
    //        console.writeline("-------------------------");
    //    }
    //}


    public Item GetByIdItem(int id)
    {
        return _context.Items.Find(id);

    }

}
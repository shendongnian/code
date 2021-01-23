    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    
    using Dapper;
    
    // to have a play, install Dapper.Rainbow from nuget
    
    namespace TestDapper
    {
        class Program
        {
            // no decorations, base class, attributes, etc 
            class Product 
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public DateTime? LastPurchase { get; set; }
            }
    
            // container with all the tables 
            class MyDatabase : Database<MyDatabase>
            {
                public Table<Product> Products { get; set; }
            }
    
            static void Main(string[] args)
            {
                var cnn = new SqlConnection("Data Source=.;Initial Catalog=tempdb;Integrated Security=True");
                cnn.Open();
    
                var db = MyDatabase.Init(cnn, commandTimeout: 2);
    
                try
                {
                    db.Execute("waitfor delay '00:00:03'");
                }
                catch (Exception)
                {
                    Console.WriteLine("yeah ... it timed out");
                }
    
    
                db.Execute("if object_id('Products') is not null drop table Products");
                db.Execute(@"create table Products (
                        Id int identity(1,1) primary key, 
                        Name varchar(20), 
                        Description varchar(max), 
                        LastPurchase datetime)");
    
                int? productId = db.Products.Insert(new {Name="Hello", Description="Nothing" });
                var product = db.Products.Get((int)productId);
    
                product.Description = "untracked change";
    
                // snapshotter tracks which fields change on the object 
                var s = Snapshotter.Start(product);
                product.LastPurchase = DateTime.UtcNow;
                product.Name += " World";
                
                // run: update Products set LastPurchase = @utcNow, Name = @name where Id = @id
                // note, this does not touch untracked columns 
                db.Products.Update(product.Id, s.Diff());
    
                // reload
                product = db.Products.Get(product.Id);
                
    
                Console.WriteLine("id: {0} name: {1} desc: {2} last {3}", product.Id, product.Name, product.Description, product.LastPurchase);
                // id: 1 name: Hello World desc: Nothing last 12/01/2012 5:49:34 AM
    
                Console.WriteLine("deleted: {0}", db.Products.Delete(product.Id));
                // deleted: True 
    
    
                Console.ReadKey();
            }
        }
    }

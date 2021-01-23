    using(TestEntities context = new TestEntities())
    {
           var item = context.TestTables.Single(s => s.ID == 1);//item.Name is "Giorgi"
    
           item.Name = "Hello";
   
           using(TestEntities context = new TestEntities())
           {
               var item1 = context.TestTables.Single(s => s.ID == 1);
               Console.WriteLine(item1.Name); // you will get old value here
           }
    }

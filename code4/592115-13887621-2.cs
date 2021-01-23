       void AddNewObject()
       {
             dataBase context = new Context;
             TableA a = new TableA();
             TableB b = new TableB();
 
             a.Id = this.Id;
             a.OtherField = this.OtherField;
             b.Key = this.BKey;
             b.SomeInt = this.SomeInt;
             context.AddObject("TableA", a);
             context.AddObject("TableB", b);
             context.SaveChanges();
       }

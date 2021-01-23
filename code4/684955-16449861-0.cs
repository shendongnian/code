    public void method()
    {
         using(MyDatabase db = new MyDatabase())
         {
             timeDB.insert(var.time);
             codeDB.insert(var.code);
             foreach (variable var in listOfVariables)
             {
                 nameDB.insert(var.value);
             }
             using (TransactionScope testScope = new TransactionScope())
             {
                  db.SaveChanges();
                  testScope.Complete();      
             }
        }
    }

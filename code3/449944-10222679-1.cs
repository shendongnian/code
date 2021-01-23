     public void AddDessert(string dessert)
       {
           using (var transScope = new TransactionScope())
           {
               try
               {
                   // ...
                   StatusDefinition statusDefinition = new StatusDefinition() {Name = dessert};
                   db.StatusDefinitions.AddObject(statusDefinition);
                   db.SaveChanges();
                   Console.WriteLine("object id:"+statusDefinition.StatusDefinitionId);
                   throw new Exception("hee hee");
                   transScope.Complete();
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.ToString());
               }
           }
       }

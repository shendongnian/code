    using (MovieStoreEntities context = new MoveStoreEntities()) 
        { 
          try 
          { 
           
            context.Movies.AddObject(new Movie() { MovieID = 234,  
                 Title = "Sleepless Nights in Seattle", Quantity = 10 }); 
            context.SaveChanges(); 
          } 
          catch(Exception ex)  
          { 
            Console.WriteLine(ex.InnerException.Message);  
          } 
        } 

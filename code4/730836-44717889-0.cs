     using (var dbContext = new Chat_ServerEntities())
     {
         var allRec= dbContext.myEntities;
         dbContext.myEntities.RemoveRange(allRec);
         dbContext.SaveChanges();
     }

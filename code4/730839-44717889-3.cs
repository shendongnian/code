     using (var dbContext = new Chat_ServerEntities())
     {
         var singleRec = dbContext.ChatUserConnections.FirstOrDefault( x => x.ID ==1);// object your want to delete
         dbContext.ChatUserConnections.Remove(singleRec);
         dbContext.SaveChanges();
     }

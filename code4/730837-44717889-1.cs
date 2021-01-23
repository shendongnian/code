     using (var dbContext = new Chat_ServerEntities())
     {
         var singleRec = dbContext.ChatUserConnections.FirstOrDefault(); // object your want to delete
         dbContext.ChatUserConnections.Remove(singleRec);
         dbContext.SaveChanges();
     }

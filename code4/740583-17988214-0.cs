       DateTime from=new DateTime(...); 
       DateTime into=new DateTime(...); 
       
       IList<User> allUsers=...
    
       IList<User> foundedUsers=allUsers.Where(Birthday.Ticks>from.Ticks && Birthday.Ticks<into.Ticks).ToList();
   

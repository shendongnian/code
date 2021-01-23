    public async void updateUser()
    {
       long UserID = await CheckIfUserExist(temp);       
       if (UserID == -1)
           // WRONG RESULT <---
       else
          // RIGHT RESULT <---
    }
- - - - - - - - - -
    public async Task<long> CheckIfUserExist()
    {                
         long UserID = -1;
         await client.GetAsync("me");  
         client.GetCompleted += (o, e) =>
         {
             // some code
             if (Convert.ToInt64(eargs.Result) == 0)
             {
                   UserID = Convert.ToInt64(eargs.Result);
             }
             return UserID;
         }
     }

        public static long CheckIfUserExist()
        {                
         long UserID = -1;
         client.GetAsync("me");  
         client.GetCompleted += MyEventHandler;
             
        }
        void MyEventHandler(object sender, SomeEventArgs e)
        {
             // some code
             if (Convert.ToInt64(eargs.Result) == 0)
             {
               UserID = Convert.ToInt64(eargs.Result);
             }
             return UserID; // <-- WHAT IS POINT OF RETURNING UserID FROM HERE?? 
                            // method maybe running on some other thread asynchronously to UI thread
        }

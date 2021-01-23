    public bool LogIn(string userId, string passwd)
        {
            bool prompt;
            ProgDBEntities context = new ProgDBEntities();
    
            var haslo = (from p in context.UserEntity where p.UserID == userId select p.Passwd).FirstOrDefault();
    
            // No need to use String.Equals explicitly
            bool passOk = haslo == passwd;
    
    
            if (passOk == true )
            {
                prompt = true;                
            }
            else
            {
                prompt = false;               
            }
            return prompt;
        }

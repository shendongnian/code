     public void findNewPartner(string School, string Major)
        {
            SoloUser soloUser = null;
            lock (soloUsers)
            {
                soloUser = soloUsers.FirstOrDefault(s => (s.School == School) && (s.Major == Major));
            }
            string sessionId = null;
            // will we be creating a new soloUser?
            if (soloUser == null)
            { 
                // then we'll need a new session for that new user
                sessionId = TokenHelper.GenerateSession();
            }
                
            lock (soloUsers)
            {
                soloUser = soloUsers.FirstOrDefault(s => (s.School == School) && (s.Major == Major));
                if (soloUser != null)
                {
                    // woops! Guess we don't need that sessionId after all.  Oh well! Carry on...
                    if (soloUser.ConnectionId != Context.ConnectionId)
                    {                                                                     
                        soloUsers.Remove(soloUser);
                    }
                }
                else
                {   
                    // use the sessionid computed earlier
                    soloUser = new SoloUser
                    {
                        Major = Major,
                        School = School,
                        SessionId = sessionId,
                        ConnectionId = Context.ConnectionId
                    };
                    soloUsers.Add(soloUser);
            }
        } 

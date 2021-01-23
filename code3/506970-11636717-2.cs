     public void findNewPartner(string School, string Major)
        {
            SoloUser soloUser = null;
            lock (soloUsers)
            {
                soloUser = soloUsers.FirstOrDefault(s => (s.School == School) && (s.Major == Major));
            }
            string sessionId = null;
            if (soloUser == null)
            { 
                sessionId = TokenHelper.GenerateSession();
            }
                
            lock (soloUsers)
            {
                soloUser = soloUsers.FirstOrDefault(s => (s.School == School) && (s.Major == Major));
                if (soloUser != null)
                {
                    if (soloUser.ConnectionId != Context.ConnectionId)
                    {                                                                     
                        soloUsers.Remove(soloUser);
                    }
                }
                else
                {   
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

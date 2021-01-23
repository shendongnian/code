     public void findNewPartner(string School, string Major)
        {
            SoloUser soloUser = null;
            lock (soloUsers)
            {
                SoloUser soloUser = soloUsers.FirstOrDefault(s => (s.School == School) && (s.Major == Major));
                
                if (soloUser != null)
                {
                    if (soloUser.ConnectionId != Conext.ConnectionId)
                    { 
                        // remove from list while holding the lock
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
                }
            }
            if (soloUser != null)
            {
                if (soloUser.ConnectionId != Context.ConnectionId)
                {
                    // generate token outside of lock. This is local to current thread.
                    // No other thread should have this soloUser instance.
                    string Token = TokenHelper.GenerateToken(soloUser.Session)
                 }
            }
            else
            {   
                string session = "mysession";                                     
                string token = TokenHelper.GenerateModeratorToken(session);
            }
        }

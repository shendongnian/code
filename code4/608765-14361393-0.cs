     try
                {
                    Ping ping = new Ping();
                    ping.PingCompleted += (sender, e) =>
                    {
                        if (e.Reply.Status != IPStatus.Success)
                            // Report fail
                        else                    
                           // Report success
                        
                    };
                    ping.SendAsync(target, 3000, target); // Timeout is 3 seconds here
                }
                catch (Exception)
                {
                    return;
                }

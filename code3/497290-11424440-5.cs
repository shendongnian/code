     protected int GetCurrentOnlineUsers()
            {
                int total = 0;
                Dictionary<string, DateTime> Visitors = (Dictionary<string, DateTime>)Application["Visitors"];
                foreach (KeyValuePair<string, DateTime> pair in Visitors)
                {
                    TimeSpan Remaining = DateTime.Now - pair.Value;
                    int remainingMinutes = Remaining.Minutes;            
                    if (remainingMinutes < 21) //Only count the visitors who have been active less than 20 minutes ago.
                        total++;
                }
        
                return total;
            }

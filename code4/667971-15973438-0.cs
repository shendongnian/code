                       string[] times = date.ToString().Split('.');
    
                        if (date != 0.0)
                        {
                            string minutesString = times[1];
                            string hoursString = times[0];
                            double minutes = Convert.ToDouble(minutesString);
                            double hours = Convert.ToDouble(hoursString);
    
                            // end of splitting
                            TimeSpan Limit = TimeSpan.FromHours(limit);
    
                            TimeSpan Hours = TimeSpan.FromHours((int)hours);
                            TimeSpan Minutes = TimeSpan.FromMinutes((int)minutes);
    
                            TimeSpan SubTotal = Hours + Minutes;
    
                            Time = Limit - SubTotal;
                        }

                    List<TimeEvent> timeEvents = new List<TimeEvent>();
                    
                    //dummy values.
                    DateTime now = DateTime.Now;
                    for (int i = 0; i < 8; i++)
                    {
                        timeEvents.Add(new TimeEvent() { Id = i, EventDate = now, CheckIn = false });
                        timeEvents.Add(new TimeEvent() { Id = i, EventDate = now, CheckIn = true });
                        now = now + TimeSpan.Parse("1");
                    }
                    
                    //group by 
                    var dataSet = timeEvents.GroupBy(a => a.EventDate.Date);
                    List<Diff> diffs = new List<Diff>();
                    foreach (var x in dataSet) 
                    {
                        if (!(x.Count() == 1))
                        {
                            diffs.Add(new Diff() { Date = x.ElementAt(0).EventDate.Date, CheckInTime = (x.ElementAt(0).CheckIn == true) ? x.ElementAt(0).EventDate : x.ElementAt(1).EventDate, CheckOutTime = (x.ElementAt(0).CheckIn == false) ? x.ElementAt(0).EventDate : x.ElementAt(1).EventDate });
                            
                        }
                        
                    }
        
                    //diffs list is full. now you can use the diffs as you like :)
        
            

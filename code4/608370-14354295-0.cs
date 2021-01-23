        using System;
            using System.Collections.Generic;
            using 
    
    System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    List<TimeEvent> timeEvents = new List<TimeEvent>();
                    DateTime now = DateTime.Now;
                    for (int i = 0; i < 8; i++)
                    {
                        timeEvents.Add(new TimeEvent() { Id = i, EventDate = now, CheckIn = false });
                        timeEvents.Add(new TimeEvent() { Id = i, EventDate = now, CheckIn = true });
                        now = now + TimeSpan.Parse("1");
                    }
        
                    var dataSet = timeEvents.GroupBy(a => a.EventDate);
                    List<Diff> diffs = new List<Diff>();
                    foreach (var x in dataSet) 
                    {
                        if (!(x.Count() == 1))
                        {
                            diffs.Add(new Diff() { Date = x.ElementAt(0).EventDate.Date, CheckInTime = (x.ElementAt(0).CheckIn == true) ? x.ElementAt(0).EventDate : x.ElementAt(1).EventDate, CheckOutTime = (x.ElementAt(0).CheckIn == false) ? x.ElementAt(0).EventDate : x.ElementAt(1).EventDate });
                            
                        }
                        
                    }
        
                    //diffs list is full. now you can use the diffs as you like :)
        
                    
                } 
            }
            public class TimeEvent
            {
                public int Id
                { get; set; }
                public DateTime EventDate
                { get; set; }
                public bool CheckIn
                { get; set; }
            }
            public class Diff
            {
                public DateTime Date //The date of both events
                { get; set; }
                public DateTime CheckInTime //Time of first event
                { get; set; }
                public DateTime CheckOutTime //Time of second event
                { get; set; }
                public int Hours //Difference in hours.
                {
                    get { return (CheckOutTime - CheckInTime).Hours; }
                }
            }
        }

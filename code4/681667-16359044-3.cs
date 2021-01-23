    public class CallHour
    {
         private readonly DateTime time;
         public CallHour(
                DateTime day,
                int hour,
                int callCount,
                int? queueId = null)
         {
             this.hour = new DateTime(
                 day.Year,
                 day.Month,
                 day.Day,
                 hour,
                 0,
                 0,
                 0);
             this.CallCount = callCount;
             this.QueueId = queueId;
         }
         public DateTime Time
         {
             get
             {
                 return this.time;
             }
         }
         public int? QueueId { get; set; }
         public int CallCount { get; set; }
    }    
 

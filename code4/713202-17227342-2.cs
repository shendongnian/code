    void Main()
    {
      List<Event> eList = new List<Event>();
      eList.Add(new Event(new DateTime(2000,1,1),new DateTime(2000,5,1)));
      eList.Add(new Event(new DateTime(2000,2,1),new DateTime(2000,2,1)));
       
      var datelist = eList.Select(item => new { t = "open", d = item.open, s = item.open.Ticks*10 })
            .Concat(eList.Select(item => new { t = "close", d = item.close, s = (item.close.Ticks*10)+1 }))
            .OrderBy(item => item.s);
      
      var max = datelist.Aggregate(
                new { curCount = 0, max = 0 },
                (result,item) => {
                   if (item.t == "open")
                   {
                      if (result.max < (result.curCount+1))
                        return(new { curCount = result.curCount+1, max = result.curCount+1 });
                      else
                        return(new { curCount = result.curCount+1, max = result.max });
                   }
                   else
                     return(new { curCount = result.curCount-1, max = result.max });
                },
                result => result.max);
                
       max.Dump();
    }
    
    // Define other methods and classes here
    
    public class Event
    {
        public DateTime open { get; set; }
        public DateTime close { get; set; }
        
        public Event(DateTime inOpen, DateTime inClose)
        {
          if (inOpen <= inClose)
          {
            open = inOpen;
            close = inClose;
          }
          else throw(new Exception("Can't close at "+inClose.ToShortDateString()+" before you open at "+inOpen.ToShortDateString()));
        }
    }

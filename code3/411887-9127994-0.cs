    class Counter
    {
       // this is the count field used to save the current count value
       private int count;
       // this is the event member which holds all the methods other objects have specified
       public event CounterIs100Delegate CounterIs100;
       
       // This is a method. It invokes the CounterIs100 event member if anyone has subscribed to it
       protected void OnCounterIs100()
       {
           // see if anyone has subscribed (linked) their method to this event
           if (CounterIs100 != null)
           {
              // invoke the event - this will call all subscribed methods
              CounterIs100();
           }
       }
    
       // This is a method. It increments the counter variable stored by this object
       public void Increment()
       {
          count++;
          // if the count is 100, invoke the event
          if (count == 100)
             OnCounterIs100();
       }
    
    }
    // This is a delegate. It is used to define a template for other objects wishing to
    // subscribe to the CounterIs100 event. The methods other objects link to the
    // CounterIs100 event must match this declaration (although the name can be changed)
    public delegate void CounterIs100Delegate();
    // This is a class, unrelated to Counter, but uses its events
    class SiteHits
    {
         Counter hitCounter = new Counter();
         public SiteHits()
         {
             // We want to know when the number of site hits reaches 100.
             // We could monitor this ourselves, but we know the Counter class already
             // does this, so we just link our method to its event
             hitCounter.CounterIs100 += this.WhenSiteHitsReaches100;
         }
         
         public void PageRequested()
         {
             // someone has requested a page - increment the hit counter
             Console.WriteLine("We've been hit!");
             hitCounter.Increment();            
         }
         // this is the method we want called when the CounterIs100 event occurs.
         // note that the return value and parameters match CounterIs100Delegate above.
         public void WhenSiteHitsReaches100()
         {
             Console.WriteLine("Woohoo! We've reached 100 hits!");
         }
    }

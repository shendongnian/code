    public class ValueHolder
    {
      public int Value = 0;
    }
    
    Cache.Insert("tryin", new ValueHolder(){Value = 0}, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration);

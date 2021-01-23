    public class TestClass
    {
    
       private event EventHandler UnderlyingEvent;
       public event EventHandler TestEvent
       {
            add
            {
                 UnderlyingEvent += value;
            }
            remove
            {
                 UnderlyingEvent -= value;
            }
       }
    }

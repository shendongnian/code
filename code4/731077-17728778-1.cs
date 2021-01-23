    public class Calendar
    {
        public Calendar(ITimer timer)
        {
            // timer is the dependency injected timer
            timer.SetEvent(EventReminder, 3600);
        }
    
        public void EventReminder()
        {
            Console.Write("Hey, it's time for your appointment!");
        }
        
    }
    
    public interface ITimer()
    {
        void SetEvent(delegate callbackMethod, int interval);
    }

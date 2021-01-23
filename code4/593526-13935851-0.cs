    public class EventFactory
    {
        public Event CreateEvent(string eventType, string eventName)
        {
            switch(enventType)
            {
                case "Leisure":
                     Leisure myLes = new Leisure(); 
                     myLes.eventNames(eventName);  
                     return myLes;
                // case Add other specialized events here:
                // break;
                default:
                     return null;
            }
        }
    }

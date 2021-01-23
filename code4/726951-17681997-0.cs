    public class Notifier
    {
        public static void NotifyAll(NotificationType type, object obj)
        {
            var context = GlobalHost.ConnectionManager.GetConnectionContext<EventDispatcher>();
            var output = ConstructEvent(type, obj);
            context.Connection.Broadcast(output);
        }
    
        protected static object ConstructEvent(NotificationType type, object obj)
        {
            var notevent = new { Event = type.ToString(), Data = obj };
            return notevent;
        }
    }
    
       

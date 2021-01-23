    class Program
    {
        static void Main(string[] args)
        {
            var typeWithEvent = new TypeWithEvent();
            var typeWithEventHandler = new TypeWithEventHandler();
            SubscribeEvent("EventTest", "EventHandlerMethod", typeWithEvent, typeWithEventHandler);
            EventArgs e = new EventArgs();
            Console.WriteLine("Event is about to be raised.");
            typeWithEvent.OnTimeToRaiseTheEvent(e);
            Console.WriteLine("Event trigger is completed.");
            Console.ReadLine();
        }
        static bool SubscribeEvent(string eventName, string handlerMethodName, object objectOnWhichTheEventIsDefined, object objectOnWhichTheEventHandlerIsDefined)
        {
            try
            {
                var eventInfo = objectOnWhichTheEventIsDefined.GetType().GetEvent(eventName);
                var methodInfo = objectOnWhichTheEventHandlerIsDefined.GetType().
                GetMethod(handlerMethodName);
                // Create new delegate mapping event to handler
                Delegate handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, objectOnWhichTheEventHandlerIsDefined, methodInfo);
                eventInfo.AddEventHandler(objectOnWhichTheEventIsDefined, handler);
                return true;
            }
            catch (Exception ex)
            {
                // Log failure!
                var message = "Exception while subscribing to handler. Event:" + eventName + " - Handler: " + handlerMethodName + "- Exception: " + ex;
                Debug.Print(message);
                return false;
            }
        }
    }
    internal class TypeWithEvent
    {
        public event EventHandler<EventArgs> EventTest;
        internal void OnTimeToRaiseTheEvent(EventArgs e)
        {
            EventHandler<EventArgs> temp = Volatile.Read(ref EventTest);
            if (temp != null) temp(this, e);
        }
    }
    internal class TypeWithEventHandler
    {
        public void EventHandlerMethod(Object sender, EventArgs e)
        {
            Console.WriteLine("From the event handler method.");
        }
    }

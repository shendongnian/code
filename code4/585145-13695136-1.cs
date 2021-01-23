    public class Form1 : Form
    {
        EventClass eventClassInstance;
        public Form()
        {
            eventClassInstance = new EventClass();
            eventClassInstance.actualEvent += new EventClass.CustomEventHandler(eventHandler);
        }
        private void eventHandler(object sender)
        {
            //Do something
        }
    }
    public class EventClass
    {
        public delegate void CustomEventHandler(object sender);
        public CustomEventHandler actualEvent;// This gets fired somewhere
        public EventClass()
        {
            
        }
    }

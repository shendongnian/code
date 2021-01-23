    public class Form1 : Form
    {
        EventClass eventClassInstance;
        public Form()
        {
            eventClassInstance = new EventClass();
            eventClassInstance.actualEvent += new EventClass.CustomEvent(eventHandler);
        }
        private void eventHandler(object sender)
        {
            //Do something
        }
    }
    public class EventClass
    {
        public delegate void CustomEvent(object sender);
        public CustomEvent actualEvent;// This gets fired somewhere
        public EventClass()
        {
            
        }
    }

    public partial class Form1 : Form //Main form class
    {
        private TextBox itemInput;
        private TextBox txtOutput;
        private string eventType; //used for event type selection
        private string formEventName; //used to store selected event name
    
        private void itemSend_Click(object sender, EventArgs e)
        {
            string name = itemInput.Text;
            try
            {
                Event myEvent = Event.Create(eventType, name);
                txtOutput.Text = "Event name is " + myEvent.Name + "\r\n";
            }
            catch (ArgumentException ex)//if the event name isn't valid
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
    public abstract class Event
    {
        public string Name { get; private set; }
        public Event(string eventName)
        {
            Name = eventName;
        }
        public static Event Create(string eventType, string eventName)
        {
            if (eventType == "Leisure")
            {
    
                Leisure myLes = new Leisure(eventName);
                return myLes;
    
            }
            //  else if { ... } test for other event types
            else
            {
                return null;
            }
        }
    }
    
    public class Leisure : Event
    {
        private static List<string> myEventNames =
            new List<string>() { "music", "Music" };
        public Leisure(string eventName)
            : base(eventName)
        {
            if (!myEventNames.Contains(eventName))
            {
                throw new ArgumentException("Not a valid Leisure event name");
            }
        }
    }

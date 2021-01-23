    public class Program
    {
        private static void Main(string[] args)
        {
            Checkbox checkbox = new Checkbox(OnChecked);
            checkbox.TriggerChecked();
        }
        private static void OnChecked(object sender, EventArgs args)
        {
            Console.WriteLine("triggered event");
        }
    }
    public class Checkbox
    {
        public event EventHandler<EventArgs> Checked;
        public Checkbox(EventHandler<EventArgs> eventHandler)
        {
            Checked += eventHandler;
        }
        public void TriggerChecked()
        {
            var handler = Checked;
            if (handler != null)
                handler(this, new EventArgs());
        }
    }

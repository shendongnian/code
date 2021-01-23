    // With events...
    public class Button
    {
        public event EventHandler Click;
    }
    public void Client
    {
        public void Method(Button button)
        {
            // This is all I can do...
            button.Click += SomeHandler;
        }
    }
    // With plain delegate fields or properties...
    public class Button
    {
        public EventHandler Click { get; set; }
    }
    public void Client
    {
        public void Method(Button button)
        {
            // Who cares if someone else is already subscribed...
            button.Click = SomeHandler;
            // And let's just raise the event ourselves...
            button.Click(button, EventArgs.Empty);
        }
    }

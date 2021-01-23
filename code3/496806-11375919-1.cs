    public class MouseObject
    {
        public MouseButton Left { get; set; }
        // Left still needs to be intialized, preferably in the constructor
    }
    public class MouseButton
    {
        public event EventHandler PressedEvent;
    }

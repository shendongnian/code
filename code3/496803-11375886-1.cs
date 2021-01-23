    struct MouseButton
    {
        internal void OnPressed()
        {
            if (PressedEvent != null)
                PressedEvent(this, EventArgs.Empty);
        }
        public event EventHandler PressedEvent;
        public event EventHandler ReleasedEvent;
    }
    class MouseObject
    {
        public MouseButton Left { get; private set; }
        public MouseButton Right { get; private set; }
        public void OnLeftPressed()
        {
            Left.OnPressed();
        }
    }
    static void Main(string[] args)
    {
        var m = new MouseObject();
        m.Left.PressedEvent += (s, e) => Console.WriteLine("pressed");
        m.OnLeftPressed();
    }

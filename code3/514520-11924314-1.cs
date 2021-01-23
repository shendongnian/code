    class KeyEvent : BaseEvent
        {
            public bool pressed;
    
            public KeyEvent(double _time, bool _pressed)
                : base(_time)
            {
                pressed = _pressed;
            }
        }
    // [...]
    // Key down
    EventSystem.RaiseEvent<KeyEvent>(eventType, new KeyEvent(time, true));
    // Key up
    EventSystem.RaiseEvent<KeyEvent>(eventType, new KeyEvent(time, false));

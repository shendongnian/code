    public struct Item
    {
        public Item(byte pin, bool status, bool state)
        {
            Pin = pin;
            Status = status;
            State = state;
        }
    
        public byte Pin;
        public bool Status;
        public bool State;
    }

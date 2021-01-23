    public class RSwitchable : Role
    {
        private bool on = false;
        public void TurnOn() { on = true; }
        public void TurnOff() { on = false; }
        public bool IsOn { get { return on; } }
        public bool IsOff { get { return !on; } }
    }
    
    public class RTunable : Role
    {
        public int Channel { get; private set; }
        public void Seek(int step) { Channel += step; }
    }
    
    public class Radio : Does<RSwitchable>, Does<RTunable> { }

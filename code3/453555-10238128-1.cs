    public class ButtonClickedEventArgs : EventArgs
    {
        public int EventInteger { get; private set; }
    
        public ButtonClickedEventArgs(int i)
        {
            EventInteger = i;
        }
    }

    public class CustomKeyEventArgs : KeyEventArgs
    {
        public char LastCharPressed { get; set; }
        public CustomKeyEventArgs(Keys keyData, char lastCharPressed) : base(keyData)
        {
            LastCharPressed = lastCharPressed;
        }
    }

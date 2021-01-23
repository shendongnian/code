    public class MyEventArgs : EventArgs
    {
        public string Text { get; private set; }
    
        public MyEventArgs(string Text)
        {
            this.Text = Text;
        }
    }

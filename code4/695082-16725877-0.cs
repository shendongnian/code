    public class MyEventArgs : EventArgs
    {
        private string MyField { get; private set; }
        public MyEventArgs(string myField)
        {
            MyField = myField;
        }
    }

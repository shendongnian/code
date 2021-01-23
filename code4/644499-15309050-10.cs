    public delegate void MyEventHandler(object source, MyEventArgs e);
    public class MyEventArgs : EventArgs
    {
        private List<string> EventInfo;
        public MyEventArgs(List<string> strings)
        {
            EventInfo = strings;
        }
        public List<string> GetInfo()
        {
            return EventInfo;
        }
    }

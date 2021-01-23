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

    internal class ClocknameEventArgs : EventArgs
    {
        public ClockNameEventArgs(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }

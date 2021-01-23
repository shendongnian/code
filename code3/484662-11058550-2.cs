    public sealed class Status
    {
        private readonly string _name;
        private readonly string _value;
        public static readonly Status New = new Status("N", "New");
        public static readonly Status Approved = new Status("A", "Approved");
        public static readonly Status OnHold = new Status("H", "On Hold");
        private Status(string value, string name)
        {
            _name = name;
            _value = value;
        }
        public string GetValue()
        {
            return _value;
        }
        public override string ToString()
        {
            return _name;
        }
    }

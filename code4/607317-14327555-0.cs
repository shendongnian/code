    interface IItem
    {
        string Prop1 { get; set; }
        object Prop2 { get; set; }
    }
    class SomeClass : IItem
    {
        public string Prop1
        {
            get;
            set;
        }
        public object Prop2
        {
            get;
            set;
        }
    }

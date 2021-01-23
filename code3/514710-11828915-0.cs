    public partial class A
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
    public partial class A
    {
        public string PropertyC
        {
            get
            {
                var val = this.PropertyA;
                // some more functionality maybe...
                return val;
            }
            set
            {
                // some more functionality maybe...
                this.PropertyA = value;
            }
        }
    }

    Class Foo
    {
        public Bar b1 { get; set; }
        public Bar b2 { get; set; }
        public Bar b3 { get; set; }
        public bool MyProp
        {
            set
            {
                if (this.b1 != null)
                {
                    this.b1.MyProp = value;
                }
                if (this.b2 != null)
                {
                    this.b2.MyProp = value;
                }
                if (this.b3 != null)
                {
                    this.b3.MyProp = value;
                }
            }
        }
    }

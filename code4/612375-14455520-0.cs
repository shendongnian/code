    public class Class1
    {
        public virtual string Lol { get; set; }
    }
    class Class1Impl1 : Class1
    {
        [Browsable(false)]
        public override string Lol
        {
            get
            {
                return base.Lol;
            }
            set
            {
                base.Lol = value;
            }
        }
    }
    class Class1Impl2 : Class1
    {
        [Browsable(true)]
        [ReadOnly(true)]
        public override string Lol
        {
            get
            {
                return base.Lol;
            }
            set
            {
                base.Lol = value;
            }
        }
    }

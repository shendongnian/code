    class Base
    {
        // base property
        public virtual string Name
        {
            get { return "Base"; }
        }
    }
    class Overriden : Base
    {
        // overriden property
        public override string Name
        {
            get { return "Overriden"; }
        }
    }
    class New : Base
    {
        // new property, hides the base property
        public new string Name
        {
            get { return "New"; }
        }
    }

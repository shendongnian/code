    public class Son : Parent 
    {
        [SonAttribute]
        public override string Name 
        { 
            get { return base.Name; }
            set { base.Name = value; }
        }
    }

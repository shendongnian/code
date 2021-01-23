    public class HasHistory<T>
    {
        public HasHistory() 
        {
            History = new History<T>();
        }
        public virtual History<T> History { get; protected set; }
    }
    public class MyHistory<T> : HasHistory<T>
    {
        public MyHistory()
            : base()
        {}
        [BSONElement("some name")]
        public override History<T> History 
        { 
            get
            {
                return base.History;
            }
            protected set
            {
                base.History = value;
            }
        }
    }

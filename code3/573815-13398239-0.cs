    public class Foo
    {
        protected string _property1;
        public virtual string Property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        public DateTime CreatedDate { get; set;}
        /* ... */
    }
    public class HistoricalFoo : Foo
    {
        public override string Property1
        {
            get
            {
                return GetHistoricalValue("Property1");
            }
        }
    }

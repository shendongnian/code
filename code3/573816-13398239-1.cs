    public class Foo
    {
        public bool IsInHistoryMode { get; set; }
        protected string _property1;
        public virtual string Property1
        {
            get
            {
                if(IsInHistoryMode)
                {
                    return GetHistoricalValue("Property1");
                }
                return _property1;
            }
            set
            {
                _property1 = value;
            }
        }
        public DateTime CreatedDate { get; set;}
        /* ... */
    }

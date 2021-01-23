    public class Chart : BaseChart
    {
        [Browsable(false)]
        public new string BaseString // notice the new keyword!
        {
            get { return base.BaseString; } // notice the base keyword!
            set { base.BaseString = value; }
        }
        // etc.
    }
    public class BaseChart
    {
        public string BaseString { get; set; }
    }
 

    public class MyValues
    {
        private readonly static MyValues instance = new MyValues();
    
        private MyValues() { }
    
        public static MyValues Instance
        {
            get { return instance; }
        }
    
        public string SomeValue { get; set; }
    
        public int SomeOtherValue { get; set; }
    }

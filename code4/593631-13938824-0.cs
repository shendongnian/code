    abstract class url
    {
        public virtual string URL { get; } // This is invalid syntax!
    }
    class b : url
    {
        public override string URL
        {
            get { return "http://www.example.com/api/x/?y=1"; }
        }
    }
    class c : url
    {
        public override string URL
        {
            get { return "http://www.example.com/api/z"; }
        }
    }

    public class Bar
    {
        private Lazy<string> _name = new Lazy<string>(() => LoadString());
    
        public string Name
        {
            get { return _name.Value; }
        }
    }

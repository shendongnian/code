    class InputClass
    {
        private string _yourName;
        private string _banner;
        
        public YourName
        {
           get { return _yourName; }
           set { _yourName = value; }
        }
    
        public Banner
        {
           get { return _banner; }
           set { _banner = value; }
        }
        
        public InputClass(String banner)
        {
           _banner = banner;
        }
    }

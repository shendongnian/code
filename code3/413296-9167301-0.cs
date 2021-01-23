    class InputClass
        {
            private string _yourName;
            public string _banner;
            public InputClass(String _banner)
                {
                _banner = "Enter your name";    
            }
    
            public string YourName 
            {
                 get { return _yourName; }
                 get { _yourName = value; }
            }
    
        }

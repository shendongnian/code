        class InputClass
          {
            private string _yourName;
            public string _banner;
            public InputClass(String _banner)
            {
                this._banner = _banner;    
            }
    
            public string YourName 
            {
                 get { return _yourName; }
                 set { _yourName = value; }
            }
    
        }

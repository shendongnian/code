            public string __Parameters
        {
            get { return this.recreate(); } 
            set
            {
                Parameters = parse(value));
            }
        }     
        
        public Dictionary<string, string> Parameters;

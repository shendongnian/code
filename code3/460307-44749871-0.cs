        string name;
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        string id;
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        
       
        public bocls() { }
        public bocls(string name, string id)
        {
            this.name = name;
            this.id = id;         
            
        }

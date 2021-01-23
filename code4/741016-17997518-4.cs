    private class T_Parameters
    {
        private string name = new String(' ', 16);
 
        public string Name 
        { 
            get { return this.name; }
            set { this.name = value.Remove(16); }
        }
        public byte YearsOld { get; set; } 
        public byte Day { get; set; } 
    }

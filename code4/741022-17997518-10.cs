    private class T_Parameters
    {
        private string name = new String(' ', 16);
 
        public string Name 
        { 
            get { return this.name; }
            set { this.name = value.PadRight(16, ' ').Substring(0, 16); }
        }
        public byte YearsOld { get; set; } 
        public byte Day { get; set; } 
    }

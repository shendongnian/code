    class widget {
        private int theNum;
        private bool theNumWasSet;
        public string theName;
    
        public int TheNum
        {
            get { return theNum; }
            set { theNumWasSet = true; theNum = value; }
        }
    }

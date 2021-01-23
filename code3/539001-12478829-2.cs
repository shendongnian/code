    class MySortedList: SortedList {
        private string name;
        public string Name{
            get { return this.name; }
            set { this.name=value; }
        }
        
        //you then need to wrap all the constructors you need from SortedList
    }

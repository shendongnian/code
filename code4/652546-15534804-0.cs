    class Passenger
    {
        private Int32 id;
        private string name;
    
        public Passenger(Int32 _id, string custName)
        {
            id = _id;
            name = custName;            
        }
    
        public Int32 ID
        {
            get { return id; }
        }
    
        public string Name
        {
            get { return name; }
        }
    }

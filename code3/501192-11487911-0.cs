    class Cab
    {
        public Cab()
        {
            Stations = new List<string>();
        }
    
        public string Medication { get; set; }
        public List<string> Stations { get; set; }
    
        public string StationsToString
        {
            set {}
            get { return string.Join(",", this.Stations.ToArray()); }
        }
    }

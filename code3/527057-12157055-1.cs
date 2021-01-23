    public class CityDetailViewModel
    {
        public IEnumerable<City.Grid> Detail { get; set; }
        public SelectList Statuses { get; set; }
        public string Topics { get; set; }
        public SelectList Types { get; set; }
        private List<long> _ms = new List<long>();
        public List<long> MS { 
            get { return _ms; }
            set { _ms = value; }
        }
    }

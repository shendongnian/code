    public class CityDetailViewModel
    {
        public IEnumerable<City.Grid> Detail { get; set; }
        public SelectList Statuses { get; set; }
        public string Topics { get; set; }
        public SelectList Types { get; set; }
        public List<long> MS { get; set; }
    
        public CityDetailViewModel() 
        {
            MS = new List<long>();
        }
    }

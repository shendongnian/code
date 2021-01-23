    public class Bus
    {
        private int busNumber;
        private List<CircularRoute> circularRoutes = new List<CircularRoute>();
        private List<LongDistance> longDistances = new List<LongDistance>(); 
        private const int MaxTotalRoutes = 10;
    
        public int BusNumber
        {
            get { return busNumber; }
            set { busNumber = value; }
        }
    
        public IEnumerable<CircularRoute> CircularRoutes
        {
            get { return circularRoutes; }
        }
      
        public IEnumerable<LongDistance> LongDistances
        {
            get { return longDistances; }
        }
    
        public void AddCircularRoute(CircularRoute route)
        {
            if (circularRoutes.Count + longDistances.Count == MaxTotalRoutes)
            {
                 // throw exception, do nothing, whatever 
                 return;
            }
     
            circularRoutes.Add(route);
        }
    }

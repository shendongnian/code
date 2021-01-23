    public class City : IComparable<City> 
    {
        public int Population {get;set;}
        
        public int CompareTo(City other)
        {
            return Population - other.Population;
        }
     ...
    }

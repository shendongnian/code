    class CityEqualityComparer : IEqualityComparer<City>
    {
        public bool Equals(City arg1, City arg2)
        {
            return arg1.CityId == arg2.CityId;
        }
        
        public int GetHashCode(City arg)
        {
            return arg.CityId;
        }
    }

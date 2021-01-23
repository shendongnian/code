    public class City
    {
        private string name;
        private string country;
        public City(string cityName)
        {
            Name = cityName;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
    public class CityList : CollectionBase
    {
        public CityList() : base ()
        {
        }
        public City this[int index]
        {
            get
            {
                return (City)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        public City this[string name]
        {
            get
            {
                int index = this.IndexOf(name);
                if (index < 0 || index >= this.List.Count) return null; // or assert
                return (City)List[index];
            }
            set
            {
                int index = this.IndexOf(name);
                if (index > 0 || index >= this.List.Count) return; // or assert
                List[index] = value;
            }
        }
        public virtual int IndexOf(City city)
        {
            return List.IndexOf(city);
        }
        public virtual int IndexOf(string name)
        {
            if (name == null) return -1;
            for (int i = 0; i < List.Count; i++)
            {
                if (((City)List[i]).Name.ToLower() == name.ToLower())
                    return i;
            }
            return -1;
        }
        public virtual void Insert(int index, City city)
        {
            List.Insert(index, city);
        }
        public virtual int Add(City city)
        {
            return base.List.Add(city);
        }
    }
    class Program
    {
        static void Main()
        {
            City NewYork = new City("New York");
            City Boston = new City("Boston");
            City Tampa = new City("Tampa");
            CityList cities = new CityList();
            cities.Add(NewYork);
            cities.Add(Boston);
            cities.Add(Tampa);
            Console.WriteLine(cities["Boston"].Name); // prints "Boston"
            Console.ReadKey();
        }
    }

    namespace _16828321
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Country> c = new List<Country>()
                {
                    new Country(){ Capital = "New York", CountryName = "USA"},
                    new Country(){ Capital = "Beijing", CountryName = "China"}
                };
    
                Country result = c.Find(country => country.CountryName == "China");
            }
        }
    
        public class Country
        {
            public string CountryName { get; set; }
            public string Capital { get; set; }
        }
    }

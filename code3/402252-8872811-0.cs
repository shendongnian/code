    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class City
    {
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string Name { get; set; }
    }
    public bool IsCountryReferenced(Country country, IEnumerable<City> cities)
    {
        return cities.Any(city => city.CountryID == country.ID);
    }

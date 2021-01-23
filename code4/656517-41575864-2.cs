    using System;
    
    namespace WebApplication2.Models
    {
        public class Country
        {
            public int Id { get; set; }
            public string CountryName { get; set; }
        }
    }
    
    using System;
    
    namespace WebApplication2.Models
    {
        public class City
        {
            public int Id { get; set; }
            public int CountryId { get; set; }
            public string CityName { get; set; }
    
        }
    }

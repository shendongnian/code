    public class Street
        {
            public string Name { get; set; }
        }
    
        public class City
        {
            public string Name { get; set; }
            public List<Street> Streets { get; set; }
        }
    
        public class Country
        {
            public string Name { get; set; }
            public List<City> Cities { get; set; }
        }
    
        public static List<Country> Ort()
            {
                List<Country> countries = new List<Country>();
                countries.Add(new Country()
                {
                    Name = "Country1",
                    Cities = new List<City>()
                    {
                        new City()
                        {
                            Name="City1",
                            Streets=new List<Street>()
                            {
                                new Street()
                                {
                                    Name="Street 1"
                                },
                                new Street()
                                {
                                    Name="Street 2"
                                }
                            }
                        },
                        new City()
                        {
                            Name="City2",
                            Streets=new List<Street>()
                            {
                                new Street()
                                {
                                    Name="Street 1"
                                },
                                new Street()
                                {
                                    Name="Street 2"
                                }
                            }
                        }
                    }
                });
                return countries;
                
            }

        public List<Country> GetCountryHeiracrchy()
        {
            var countries = DbContext.GetAll();
            var lstCountries = new List<Country>();
            foreach (var _country in countries)
            {
                var country = new Country { Name = _country.Name };
                foreach (var _state in _country.States)
                {
                    var state = new State() {Name = _state.Name};
                    foreach(var _county in _state.Counties)
                    {
                        var county = new County {Name = _county.Name};
                        foreach(var _city in _county.Cities)
                        {
                            var city = new City {Name = _city.Name};
                            county.Cities.Add(city);
                        }
                        state.Counties.Add(county);
                    }
                    country.States.Add(state);
                }
                lstCountries.Add(country);
            }
            return lstCountries;
        }

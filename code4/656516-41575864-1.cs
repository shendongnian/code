    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebApplication2.Models;
    
    namespace WebApplication2
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    GetData();
    
                }
            }
    
            private List<City> SetCityData()
            {
                List<City> cities = new List<City>()
                {
                    new City() { Id = 1, CountryId = 2, CityName = "Amman"  },
                    new City() { Id = 1, CountryId = 2, CityName = "Zarqa"  },
                    new City() { Id = 1, CountryId = 4, CityName = "Istanbul"  },
                    new City() { Id = 1, CountryId = 4, CityName = "Ankara"  },
                    new City() { Id = 1, CountryId = 4, CityName = "Mersin"  },
                    new City() { Id = 1, CountryId = 4, CityName = "Trabzon"  },
                    new City() { Id = 1, CountryId = 1, CityName = "Rio de Janeiro"  },
                    new City() { Id = 1, CountryId = 3, CityName = "Los Angeles"  },
                    new City() { Id = 1, CountryId = 3, CityName = "Chicago"  },
                };
                return cities;
            }
    
            protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
            {
                int selectedCountry = Convert.ToInt32(ddlCountries.SelectedValue);
                var cityByCountry = from c in SetCityData()
                                    where c.CountryId == selectedCountry
                                    select c;
                ddlCities.DataSource = cityByCountry.ToList();
                ddlCities.DataTextField = "CityName";
                ddlCities.DataValueField = "Id";
                ddlCities.DataBind();
            }
    
            private List<Country> SetCountries()
            {
                List<Country> countries = new List<Country>()
                {
                    new Country() { Id = 1, CountryName = "Brazil"  },
                    new Country() { Id = 2, CountryName = "Jordan" },
                    new Country() { Id = 3, CountryName = "USA" },
                    new Country() { Id = 4, CountryName = "Turkey" }
                };
                return countries;
            }
    
            private void GetData()
            {
                ddlCountries.DataSource = SetCountries();
                ddlCountries.DataTextField = "CountryName";
                ddlCountries.DataValueField = "Id";
                ddlCountries.DataBind();
            }
        }
    }

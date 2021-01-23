    // this goes to business logic
    public CitiesView GetCities(int id) {
           var cities = new CitiesCollection();
           var city = CustomerBLL.GetCities(index);
            //Loop through all the cities in st object
            foreach (var c in city)
            {
                //If id=0 then fill all dropdowns
                if (id == 0)
                {
                    cities.Residental.Add(c.city_name.Trim());
                    cities.Office.Add(c.city_name.Trim());
                    cities.Native.Add(c.city_name.Trim());
                    cities.Nominee.Add(c.city_name.Trim());
                }
                else
                {
                    //If 1 then fill Res City
                    if(id==1)
                        cities.Residental.Add(c.city_name.Trim());
                    //If 2 then fill Off City
                    if(id==2)
                    cities.Office.Add(c.city_name.Trim());
                    //If 3 then fill nat city
                    if(id==3)
                    cities.Native.Add(c.city_name.Trim());
                }
            }
      }
      // this goes to code behind
      public void FillCitiesDrowDowns(int id) {
           var citiesView = GetCities(id);
           NewCustomerddlResidentialCity.Items.AddRange(citiesView.Residental);
           NewCustomerddlOfficeCity.Items.Add(citiesView.Office);
           NewCustomerddlNativeCity.Items.Add(citiesView.Native);
           NewCustomerddlNomineeCity.Items.Add(citiesView.Nominee);    
     }
     public class CitiesView {
         public List<string> Residental {get;set;}
         public List<string> Office {get;set;}
         public List<string> Native {get;set;}
         public List<string> Nominee {get;set;}
     }

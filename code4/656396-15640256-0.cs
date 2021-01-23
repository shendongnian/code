    public class Customer
    {
    
        private City cityInfo;
        private string name;
    
        public long Id { get; set; }
        public bool IsCityModified { get; set;}
        public event Action<City> OnCityInfoChanged;
        public bool IsCustomerNameModified { get; set; }
    
        public string Name 
        { 
            get{ return name;} 
            set
            {
               if(name!=value)
               {
                  IsCustomerNameModified=true; }name=value;
               } 
            }
         }
    
    
        public City CityInfo 
        {
        get
            {
               if(cityInfo==null)
               {
                  cityInfo=new City();
               }
               return cityInfo;
             }
    
          set{
              if(this.cityInfo ==value)
                      return;
                 IsCityModified =true;
                 this.cityInfo=value;
                 if(OnCityInfoChanged != null)
                    OnCityInfoChanged(value);
           }   
      }
    }

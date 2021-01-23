    public partial class Jewel
    {
        private string _birthstone;
        public string Birthstone
        {
            get 
            { 
                 if (_birthstone == null)
                 {
                      JewelBusiness jewelBusiness = new JewelBusiness();
                      _birthstone = jewelBusiness.RequestBirthstone(birthmonth); 
                 }
                 return _birthstone; 
            }
        }
    }

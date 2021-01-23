    public class CountryObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public List<CountryObject> ReturnAllCountries()
    {
        ProjectTwoDataBaseDataContext DataBase = new ProjectTwoDataBaseDataContext();
        var Country = from a in DataBase.Countries
                      select new CountryObject{Id=a.Country_Id, Name=a.Country_Name };
        return Coutry.ToList();
    }

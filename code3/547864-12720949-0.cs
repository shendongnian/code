    public class CountryDto
    {
        public string Name { get; set; }
            
        public string RegionName { get; set; }
    }
        
    public partial class CountryModel : BaseNopEntityModel,
    {           
        public CountryDto[] Countries { get; set; }
        
        public string[] RegionList { get; set; }
    }

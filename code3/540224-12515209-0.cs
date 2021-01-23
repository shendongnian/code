    public class Country 
    {
      public List<Region> Regions { get; set; }
    
      public bool IsPostCodeRequiredByDefault { get; set; }
    }
    
    public class Region
    {
      private bool? _isPostCodeRequired;
    
      public Country Country { get; set; }
    
      public bool IsPostCodeRequired 
      {
        get { return _isPostCodeRequired ?? Country.IsPostCodeRequiredByDefault; }
      }
    }

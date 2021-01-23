    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class OmniData : IOmniData
    {
      public Country[] GetAllCountries()
      {
        ControlServiceRepository rep = new ControlServiceRepository();
        return rep.GetAllCountries().ToArray() ;
      }
    }

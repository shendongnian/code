    public class CompanyViewModel
    {
      public string Name { set;get;}
      public IEnumerable<SelectListItem> Countries { set;get;}
      public int SelectedCountry { set;get;}
    
      CompanyViewModel()
      {
        Countries=new List<SelectListItem>();
      }
    }

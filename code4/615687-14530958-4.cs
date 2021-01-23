    public class CreateItemVM
    {
      public string SerialNumber { set;get;}
      public int SelectedManufactureID { set;get;}
      public List<SelectListItem> Manufacturers { set;get;}
      public CreateItemVM()
      {
         Manufacturers =new List<SelectListItem>();
      }     
    }

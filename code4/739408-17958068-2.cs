    public class MyViewModel 
    {
      public MyViewModel(Data somedata)
      {
        /* populate Options */
      }
    
      public IEnumerable<SelectListItem> Options { get; set; }
      public MyForm Form { get; set; }
    }

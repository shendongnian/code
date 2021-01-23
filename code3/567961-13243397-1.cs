    public class MyViewModel
    {
      public string first_name { get; set; }
    
      public object first_name_attributes
      {
        get
        {
          return string.IsNullOrEmpty(first_name) ? null : new { "readonly" };
        }
      }
    }

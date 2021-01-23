    public class EmployeeRowViewModel
    {
      public string CssClass {get;set;}
      public string Url {get;set;}
      public string CssActive
      {
        get { return (Url == "/messages/") ? "active" : null; }
      }
      public Employee Row {get;set;}
    }

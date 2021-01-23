    public class MyObject
    {
      //other stuff
      public string DisplayValue
      {
         get { return String.Format("{0} ({1})", ID, TestID); }
      }
    }
    ddList.DataSource = DvName;
    ddList.DataTextField = "DisplayName";
    ddList.DataValueField = "DisplayValue";

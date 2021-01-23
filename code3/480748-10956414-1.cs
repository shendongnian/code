    public static class ControllerExtensions
    {
      public string GetMessage(this Controller instance)
      {
        string result = instance.TempData["Message"] as string;
        if (string == null)
        {
          result = "some default value or throw null argument exception";  
        }
      }
      public void SetMessage(this Controller instance, string value)
      {
        instance.TempData["Message"] = value;
      }
    }

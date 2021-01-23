    public static class MyTempData
    {
      public string Message
      {
        get
        {
          string result = TempData["Message"] as string;
          if (string == null)
          {
            result = "some default value or throw null argument exception";  
          }
          return result;
        }
        set
        {
          TempData["Message"] = value;
        }
    }

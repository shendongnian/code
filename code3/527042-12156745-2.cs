    public static MyDataClassesContext GetDataContext(bool isInternetAvailable)
    {
      if (isInternetAvailable)
      {
        return new MyDataClassesContext("ServerConnStringName");
      }
      else
      {
        return new MyDataClassesContext("LocalConnStringName");
      }
    }

    public void Page_Load(...)
    {
      // check whilst first loading of the page
      // if you need checking each time as page loading - remove if() below
      if (!IsPostBack)
      {
        YourConnectToDatabaseMethod(defaultParams);
      }
    }
    
    
    public void OnButtonClick(...)
    {
       var params = ... grab required params;
       YourConnectToDatabaseMethod(params);
    }
    
    private void YourConnectToDatabaseMethod(TypeOfParams params)
    {
    }

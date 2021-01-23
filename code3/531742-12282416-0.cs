    // I would consider retrieving this from web.config
    protected string testModeKey = "tm";
    public bool IsTestContext
    {
       get
       {
          return Request.QueryString[testModeKey] != null;
       }
    }

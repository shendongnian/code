    // Any Asp.Net method (webforms or mvc)
    public void SetValueMethod()
    {
      MyClassSesssion.Current.Blah1 = "asdf";
    }
    public string GetValueMethod()
    {
      return MyClassSession.Current.Blah1;
    }

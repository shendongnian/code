    public string RootCategoryId
    {
      get
      {
        return ViewState["RootCategoryId"] == null ?
           "Default Value!" :
           (string)ViewState["RootCategoryId"];
      }
      set { ViewState["RootCategoryId"] = value; }
    }

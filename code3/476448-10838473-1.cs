    public string test{
      get{
        return (string) ViewState["test"] ?? "hi";
      }
      set{
        ViewState["test"]=value;
      }
    }

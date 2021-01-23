    public  List<string> MyList 
    { 
        get 
        { 
            if (ViewState["Items"] == null)
                ViewState["Items"] = new string[0];
            return new List<string>((string[])ViewState["Items"]);
        }
        set
        {
            ViewState["Items"] = value.ToArray();
        }
    }

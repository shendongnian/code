    public List<int> CurrentList
    {
        get
        {
            if (Session["CurrentList"] == null)
                return new List<int>();
            else
                return (List<int>)Session["CurrentList"];
            
        }
        set
        {
            Session["CurrentList"] = value;
        }
    }

    public List<int> CurrentList
    {
        get
        {
            return (List<int>)Session["CurrentList"] ?? new List<int>();
        }
        set
        {
            Session["CurrentList"] = value;
        }
    }

    public List<MyData> MyData
    {
        get
        {
            if (Session["MyData"] == null)
                return new List<MyData>();
            return (List<MyData>)Session["MyData"];
        }
        set
        {
            Session["MyData"] = value;
        }
    }

    protected string Rdb1Checked
    {
        get
        {
            if (IsPostBack)
            {
                if (Request["rbdData"] == "rbd1")
                {
                    return "checked";
                }
                else
                {
                    return "";
                }
            }
    
            return "checked";
        }
    }
    
    protected string Rdb2Checked
    {
        get
        {
            if (IsPostBack)
            {
                if (Request["rbdData"] == "rbd2")
                {
                    return "checked";
                }
                else
                {
                    return "";
                }
            }
    
            return "";
        }
    }

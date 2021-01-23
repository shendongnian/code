    protected List<int> CheckedIDs
    {
        get
        {
            List<int> checkedIDs = new List<int>();
            if (Session["CheckedIDs"] != null)
            checkedIDs = (List<int>)Session["CheckedIDs"];
            return checkedIDs;
        }
        set
        {
            Session["CheckedIDs"] = value;
        }
    }

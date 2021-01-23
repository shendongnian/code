    private List<TableRow> TableRows
    {
        get
        {
            if(Session["TableRows"] == null)
                Session["TableRows"] = new List<TableRow>();
            return (List<TableRow>)Session["TableRows"];
        }
    }

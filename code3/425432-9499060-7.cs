    public DataTable _VS_RETURN_FORMAT
    {
        get
        {
            if (ViewState["_VS_RETURN_FORMAT] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("field1");
                dt.Columns.Add("field2");
    
                ViewState["_VS_RETURN_FORMAT"] = dt;
            }
            return (DataTable)ViewState["_VS_RETURN_FORMAT"];
        }
        set
        {
            ViewState["_VS_RETURN_FORMAT"] = value;
        }
    }

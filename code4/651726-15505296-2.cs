    if(ds.Tables[0].Rows.Count > 0)
    {
        object a = ds.Tables[0].Rows[0]["pic"];
        string test = a.ToString();
    }
    else
    {
        Response.Write("No rows for the ID = " + passedID);
    }

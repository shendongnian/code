    DataClassDataContext db = new DataClassDataContext();
    //storedProc takes 3 params
    string[] param = GetStringParams();
    gridview.DataSource = db.storedProc(param[0], param[1], param[2]);
    gridview.DataBind();
    private string[] GetStringParams()
    {
        //Perform some logic here to determine which params to pass
        if (somethingIsTrue)
            return new string[] { "param1", "param2", "param3" };
        else if (somethingElseIsTrue)
            return new string[] { "param1", "param2", "" };
        else
            return new string[] { "", "", "" };
    }

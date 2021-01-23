    int intCustId;
    if(int.TryParse(Request.QueryString["id"], out intCustId)
    {
      // Do stuff
    }
    else
    {
      // Handle error
    }

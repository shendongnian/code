    string ID = Request.QueryString["ID"];
    int integerId;
    if (int.TryParse(ID, out integerId))
    {
       // you have a valid integer ID here.
       // process it
    }
    else
    {
        // handle missing or invalid ID
    }

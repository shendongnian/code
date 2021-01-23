    int UnitID = 0;
    if(string.IsNullOrEmpty(Request["UnitID"]))
    {
        UnitID = 0;
    }
    else
    {
        if(!Int32.TryParse(Request["UnitID"], out UnitID))
        {
            UnitID = 0;
        }
    }

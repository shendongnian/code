        //Generate New GUID
        Guid objGuid = Guid.NewGuid();
        //Take invalid guid format
        string strGUID = "aaa-a-a-a-a";
        Guid newGuid;
        if (Guid.TryParse(objGuid.ToString(), out newGuid) == true)
        {
            Response.Write(string.Format("<br/>{0} is Valid GUID.", objGuid.ToString()));
        }
        else
        {
            Response.Write(string.Format("<br/>{0} is InValid GUID.", objGuid.ToString()));
        }
        
        Guid newTmpGuid;
        if (Guid.TryParse(strGUID, out newTmpGuid) == true)
        {
            Response.Write(string.Format("<br/>{0} is Valid GUID.", strGUID));
        }
        else
        {
            Response.Write(string.Format("<br/>{0} is InValid GUID.", strGUID));
        }

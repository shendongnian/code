    long projectId;
    if(long.TryParse(context.Request.Params["projectId"], out projectId)
    {
        if (projectId > 0)
            SerializeResults(getReportGroups(projectId), null, false, context);
        else
        {
            ThrowInvalidProjectIdException(projectId);
        }
    }
    else
    {
        //Handle the case where projectId could not be parsed as a long
    }
 

    try
    {
        client.ThisMethodHasFault("");
    }
    catch (FaultException e)
    {
        var accessor = TypeAccessor.Create(e.GetType());
        var detail = accessor.GetMembers().Any(x => x.Name == "Detail")
                         ? accessor[e, "Detail"] as BaseFault
                         : null;
        
        if (detail != null)
        {
            // Do processing here
        }
        else
        {
            throw;
        }
    }

    bool retVal = true;
    try
    {
        ObjA.CheckVersion(oldVersion); 
        objB.CheckUserRight(); 
        ObjC.ISDBExist(); 
        OjbD.ISServerUp(ServerName); 
    }
    catch (SomeException ex)
    {
        // Log ex here.
        retVal = false;
    }
    return retVal;

    public static ApplicationType AppType()   
    {
        var context = new Dll_IssueTracking.IssuTrackingEntities(); // Object context defined in Dll_IssuTracking DLL
    
        var query = from c in context.ApplicationTypes //Query to find TypeNames
                        select new { c.TypeName };
        return query.FirstOrDefault();
    }

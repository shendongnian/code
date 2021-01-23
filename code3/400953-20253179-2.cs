    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
            filters.Add(new HandleErrorAttribute());//default handler
            filters.Add(new HandleErrorEncodingAttribute());//extra check for filter disposal
    }

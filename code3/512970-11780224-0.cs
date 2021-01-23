    if(HttpContext != null && 
       HttpContext.Current != null &&
       HttpContext.Current.Session != null &&
       HttpContext.Current.Session[AppConstants.SK_POLICYCLASSID] != null)
    {
        // Get the value here.
    }
    else
    {
        // Something was null. Either set a default value or throw an Exception
    }

    public override string GetVaryByCustomString(HttpContext Context, string Custom)
    {
        if (Custom == "Culture")
        {
            // return culture specific string
            return Context.Request.UserLanguages[0];  
        }
        return base.GetVaryByCustomString(Context, Custom);
    }

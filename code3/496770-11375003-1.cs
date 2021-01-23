    public static void EnsureMyPacksFolder()
    {
        if (Session["MyPacksFolder"] == null)
        {
            // Add code to create MyPacksFolder that was previously in Session_Start
            Session["MyPacksFolder"] = true;
        }
    }

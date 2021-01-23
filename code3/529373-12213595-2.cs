    string args= Page.Request.Params.Get("__EVENTTARGET");
    if (!String.IsNullOrEmpty(args))
    {
        //Called From Update Panel(or) UpdatePanel is posting back
    }
    else
    {
        //Called From a page with no Update Panel
    }

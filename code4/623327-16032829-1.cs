    var R = new Repo();
    //Single query
    R.GetCustomQuery<AccCompany>(x => x.Code == Request.QueryString["Code"]).FirstOrDefault();
    //list query
    R.GetCustomQuery<AccCompany>(x => x.Code == Request.QueryString["Code"] && !x.IsDeleted).ToList();

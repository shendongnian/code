    if (System.Web.HttpContext.Current.Cache["UserGroup_1_Permissions"] == null)
    {
        _Permissions = DAL.getPermissions("UserGroup1") as List<Permissions>;
        System.Web.HttpContext.Current.Cache["UserGroup_1_Permissions"] = _Permissions;
    }
    else
    {
        _Permissions = System.Web.HttpContext.Current.Cache["UserGroup_1_Permissions"] as List<Permissions>;
    }

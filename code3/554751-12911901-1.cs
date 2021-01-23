        [HttpPost]
    public ActionResult Deploy(string key_name, string custom_folder = "")
    {
        string userId = Membership.GetUser().ProviderUserKey.ToString();
        UserDataModel user_info = _user_data_service.getUserDataByPrimaryIDNoDB(userId, HttpContext.Cache);
        log.Trace("Deploy was called. key_name:" + key_name + " UID: " + user_info.UID);
        // first we'll call the info to install remote application
        bool serviceInstall = _fms_app_service.DeployFmsApp(user_info, key_name, custom_folder);
        // then we'll call to generate client side info
        bool clientInstall = _fms_app_service.CompileClientApp(user_info, key_name);
        var model = _fms_app_service.getInstalledAppInfo(user_info, key_name);
        if (serviceInstall && clientInstall)
        {
            return RedirectToAction("Deploy", model);
        }
        return AjaxAwareRedirectResult("/foo");
    }

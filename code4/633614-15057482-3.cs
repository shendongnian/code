    public ActionResult SelectLanguage()
    {
        return Redirect(string.Format("/{0}{1}", base.URLReferLanguage, Request.Url.PathAndQuery));
    }
    /// <summary>
    /// URL: /en-us/LogOn
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
        string eMethod = eMethodBase + ".Index[GET]";
        using (DataRepositories _dataContext = new DataRepositories())
        {
            base.InitView(
                Resources.View_LogOn_PageTitle,
                string.Empty,
                specificCssCollection,
                specificJSCollection,
                dynamicJSCollection,
                specificJqueryJSCollection,
                jsVariables,
                externalCSS,
                Meta,
                _dataContext,
                false,
                base.RequestLanguage,
                false
            );
        }
        string returnUrl = Request.QueryString["ReturnUrl"];
        if (!string.IsNullOrEmpty(returnUrl))
        {
            ContentData.ReturnUrl = returnUrl;
        }
        return View(ContentData);
    }

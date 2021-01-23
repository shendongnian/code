            protected override void OnPreInit(EventArgs e)
            {
                base.OnPreInit(e);
    
                string userAgent = Request.UserAgent;
                bool isTablet = IsTablet(userAgent);
                bool isMobile = IsMobile(userAgent);
    
                int templateId = umbraco.NodeFactory.Node.GetCurrent().template;
                umbraco.template template = new umbraco.template(templateId);
                string templateName = StripDevice(template.TemplateAlias);
    
                if (isTablet)
                {
                    Page.MasterPageFile = GetTabletMaster(templateName);
                }
                else if (isMobile)
                {
                    Page.MasterPageFile = GetMobileMaster(templateName);
                }
                else
                {
                    Page.MasterPageFile = GetDesktopMaster(templateName);
                }
    
    }
        public string GetMobileMaster(string templateName)
        {
            try
            {
                MasterPage masterPage = new MasterPage();
                masterPage.MasterPageFile = string.Format("/masterpages/{0}mobile.master", templateName);
                if (masterPage == null)
                {
                    masterPage.MasterPageFile = string.Format("/masterpages/{0}desktop.master", templateName);
                }
                if (masterPage == null)
                {
                    return Page.MasterPageFile;
                }
                else
                {
                    return masterPage.MasterPageFile;
                }
            }
            catch (Exception ex)
            {
                umbraco.BusinessLogic.Log.Add(umbraco.BusinessLogic.LogTypes.Error, umbraco.BusinessLogic.User.GetUser(0), -1, "Switch template to MOBILE fail " + templateName + " : " + ex.Message);
                return Page.MasterPageFile;
            }
        }

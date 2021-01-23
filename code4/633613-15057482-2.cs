    public string URLReferLanguage
    {
        get
        {
            string toReturn = ConfigurationManager.AppSettings["DefaultLanguage"];
            string language = string.Empty;
            string[] tLanguages = ConfigurationManager.AppSettings["Languages"].Split(',');
            string urlReferrer = HttpContext.Request.UrlReferrer.AbsolutePath;
            if (urlReferrer != null)
            {
                if (urlReferrer.Length > 5)
                {
                    language = urlReferrer.Substring(1, 5).ToLower();
                    if (tLanguages.Contains(language))
                    {
                        toReturn = language;
                    }
                }
            }
            return toReturn;
        }
    }

            public string GetSiteLink(object SiteName)
        {
            string sn = string.Empty;
            string sHtml = string.Empty;
            if (SiteName is string)
            {
                sn = SiteName.ToString();
                if (sn == "redlionnewquay")
                {
                    sHtml = "http://www.redlionnewquay.co.uk";
                }
                else
                {
                    sHtml = "~/Venue/Home/" + SiteName;
                }
            }
            return sHtml;
        }

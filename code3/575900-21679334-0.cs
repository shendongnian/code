    private void GenerateXML()
        {
            try
            {
                string fileName         = "sitemap.xml";
 
                string DOMAIN           = "http://www.sohel-elite.com";
                string LAST_MODIFY= String.Format("{0:yyyy-MM-dd}", DateTime.Now);
                string CHANGE_FREQ      = "monthly";
                string TOP_PRIORITY     = "0.5";
                string MEDIUM_PRIORITY  = "0.8";
 
                XNamespace ns    = "http://www.sitemaps.org/schemas/sitemap/0.9";
                XNamespace xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
 
                //XDocument Start
                XDocument xDoc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "no"),
                    new XElement(ns + "urlset",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsiNs),
                    new XAttribute(xsiNs + "schemaLocation",
                        "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd"),
                    new XElement(ns + "url",
 
                        //Root Element
                        new XElement(ns + "loc",        DOMAIN),
                        new XElement(ns + "lastmod",    LAST_MODIFY),
                        new XElement(ns + "changefreq", "weekly"),
                        new XElement(ns + "priority",   TOP_PRIORITY)),
 
                        //Level0 Menu
                        from level0 in GetParentCMSMenu()
                            select new XElement(ns + "url",
                                new XElement(ns + "loc", String.Concat(DOMAIN, WebsiteHelpers.GetMenuRouteURL(Util.Parse<string>(level0.MENU_ALLIAS), Util.Parse<string>((level0.Level1 == null) ? string.Empty : level0.Level1), Util.Parse<int>(level0.APPLICATION_ID)))),
                                new XElement(ns + "lastmod",    LAST_MODIFY),
                                new XElement(ns + "changefreq", CHANGE_FREQ),
                                new XElement(ns + "priority",   MEDIUM_PRIORITY)
                            ),
 
                        //Level1 Menu
                        from level0 in GetParentCMSMenu()
                           from level1 in GetLevel1Menu(Util.Parse<int>(level0.MENU_ID))
                                select new XElement(ns + "url",
                                    new XElement(ns + "loc", String.Concat(DOMAIN, WebsiteHelpers.GetMenuRouteURL(Util.Parse<string>(level1.Level1), Util.Parse<string>((level1.MENU_ALLIAS == null) ? string.Empty : level1.MENU_ALLIAS), Util.Parse<int>(level1.APPLICATION_ID)))),
                                    new XElement(ns + "lastmod",    LAST_MODIFY),
                                    new XElement(ns + "changefreq", CHANGE_FREQ),
                                    new XElement(ns + "priority",   MEDIUM_PRIORITY)
                                ),
 
                        //Level2 Menu
                        from level0 in GetParentCMSMenu()
                            from level1 in GetLevel1Menu(Util.Parse<int>(level0.MENU_ID))
                                from level2 in GetLevel2Menu(Util.Parse<int>(level1.MENU_ID))
                                    select new
                                        XElement(ns + "url",
                                        new XElement(ns + "loc", String.Concat(DOMAIN, WebsiteHelpers.GetMenuRouteURL(Util.Parse<string>(level2.Menu), Util.Parse<string>(level2.Level1), Util.Parse<int>(level2.AppID), Util.Parse<string>(level2.Level2)))),
                                        new XElement(ns + "lastmod", LAST_MODIFY),
                                        new XElement(ns + "changefreq", CHANGE_FREQ),
                                        new XElement(ns + "priority", MEDIUM_PRIORITY)
                                    )
 
                ));
                //XDocument End
 
                xDoc.Save(Server.MapPath("~/") + fileName);
 
                this.MessageHolder.Visible = true;
                this.MessageHolder.Attributes.Add("class", "success");
                this.MessageHolder.InnerHtml = "Sitemap.xml created successfully";
 
            }
            catch (Exception ex)
            {
                this.MessageHolder.Visible = true;
                this.MessageHolder.Attributes.Add("class", "error");
                this.MessageHolder.InnerHtml = Constants.ERROR_LONG_MESSAGE + "<br/>" + ex.ToString();
            }
        }

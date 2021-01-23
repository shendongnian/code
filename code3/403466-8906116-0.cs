     public static string GetQueryStringValue(this System.Windows.Controls.Page page, string p)
            {
    
                var values = HtmlPage.Document.QueryString
                .Where(w => w.Key.Trim().Equals(p))
                .Select(s => s.Value).SingleOrDefault();
                return values;
            }
    
            public static string GetQueryStringValueFromNavigationContext(this System.Windows.Controls.Page p, string key)
            {
                var values = p.NavigationContext.QueryString
                .Where(w => w.Key.Trim().Equals(key))
                .Select(s => s.Value).SingleOrDefault();
                return values;
            }

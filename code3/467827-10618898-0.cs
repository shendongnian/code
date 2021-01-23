        protected Sitecore.Web.UI.WebControls.Sublayout CurrentSublayout
        {
            get
            {
                Control c = Parent;
                while (c != null && !(c is Sitecore.Web.UI.WebControls.Sublayout))
                {
                    c = c.Parent;
                    if (c == null)
                        break;
                }
                return c as Sitecore.Web.UI.WebControls.Sublayout;
            }
        }
        protected NameValueCollection CurrentParameters
        {
            get
            {
                if (CurrentSublayout == null)
                    return null;
                NameValueCollection parms = WebUtil.ParseUrlParameters(CurrentSublayout.Parameters);
                var sanitizedValues = new NameValueCollection();
                for (int i = 0; i < parms.Count; i++)
                {
                    if (!string.IsNullOrEmpty(parms[i]))
                        sanitizedValues.Add(parms.Keys[i], parms[i]);
                }
                return sanitizedValues;
            }
        }

    public string ItemID
            {
                get
                {
                    return StringUtil.GetString(this.ViewState["ItemID"]);
                }
                set
                {
                    Sitecore.Diagnostics.Assert.ArgumentNotNull(value, "value");
                    this.ViewState["ItemID"] = value;
                }
            }

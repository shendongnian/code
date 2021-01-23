    public System.Web.HttpPostedFile PostedFile
    {
        get
        {
            if !(this.Page == null) && (this.Page.IsPostBack) 
            {
                return this.Context.Request.Files.Item(this.UniqueID);
            }
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (currItem.HasChildren || currItem.TemplateID == new Sitecore.Data.ID("45D58815-A301-4393-9BA0-30A00C9BB993"))
                {
                    var getFirstChild = (from Item item in currItem.GetChildren()
                                         select item).First();
                    if (getFirstChild.TemplateID == new Sitecore.Data.ID("45D58815-A301-4393-9BA0-30A00C9BB993") && getFirstChild != null)
                    {
                        Response.Redirect(getFirstChild.Paths.Path);
                    }
    
                    else
                    {
                        //Load Generic Page!
                    }
                }
                else
                {
                    //Load Generic Page!!!
                }
            }
        }

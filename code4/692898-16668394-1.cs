    protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                if (conduction1)
                    this.Page.MasterPageFile = "~/MasterPage.master";
                else
                    this.Page.MasterPageFile = "~/Master.master";
            }
            catch (Exception ex)
            {
    
            }
        }

    protected void Page_Load(object sender, EventArgs e)
    {
          if (string.IsNullOrEmpty(Page.Title))
          {
               Page.Title = ConfigurationManager.AppSettings["DefaultTitle"];  //title saved in web.config
          }
    }

    // Page_Load in your master page code behind file
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.MainContent.Page is _Default)
      {
        // The default page
      }
      if (this.MainContent.Page is About)
      {
        // The About page.
      }
    }

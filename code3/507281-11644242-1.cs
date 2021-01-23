    protected void Page_Load(object sender, EventArgs e)
    {
        if(string.Compare((Request.QueryString["IsDownloading"] ?? string.Empty).Split(new char[] { ',' }).First(), "true", StringComparison.InvariantCultureIgnoreCase) == 0)
      {
        // Make a file transfer
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      // Something like ~/Folder/Default.aspx
      string file = Page.AppRelativeVirtualPath;
      // Something like ~/Folder/
      string folder = Page.AppRelativeTemplateSourceDirectory;
    }

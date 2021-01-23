    protected void Page_Load(object sender, EventArgs e)
    {
      if(!Page.IsPosBack)
      {
        Button2.Enabled = false;
      }
    }

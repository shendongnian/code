    protected void Page_Load(object sender, EventArgs e)
    {
        yourButton.Attributes.Add("onClick", "javascript:history.back(); return false;");
    }
     
    protected void yourButtonClick(object sender, EventArgs e)
    {
          Response.Write("Stackoverflow <br/>");
    }

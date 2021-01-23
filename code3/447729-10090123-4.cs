    protected void Page_Load(object sender, EventArgs e)
    {
    
      lblName.Text = "User Name";
      lblEmail.Text = "user@domain.com";
      lblPhone.Text = "555-4214";
    
      StringBuilder sb = new StringBuilder();
      StringWriter tw = new StringWriter(sb);
      HtmlTextWriter hw = new HtmlTextWriter(tw);
      tb.RenderControl(hw);
      string tableContents = sb.ToString();
    
      lblRenderedTable.Text = tableContents;
    }

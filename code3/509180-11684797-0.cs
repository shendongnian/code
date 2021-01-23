    protected void Button1_Click(object sender,EventArgs e)
    {
      foreach(ListViewDataItem item in lvArticle.Items)
       {
         HiddenField hf=(HiddenField)item.FindControl("hfBlogID");
       }
    }

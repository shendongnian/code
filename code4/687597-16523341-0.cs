    protected void gvDeals_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if(e.CommandName.Equals("MyCommand")
       {
          string value=calculate();
          Response.Redirect("~/MyPage.aspx?item=" + value);
       }
    }

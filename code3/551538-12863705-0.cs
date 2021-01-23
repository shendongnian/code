    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) 
    { 
     if (e.Row.RowType == DataControlRowType.DataRow) 
     { 
          HyperLink hl = (HyperLink)e.Row.FindControl("Link");
          if (hl != null)
          {
               DataRowView drv = (DataRowView)e.Row.DataItem;
               string keyword = drv["Keyword"].ToString().Trim();
               string state = strState.ToString().Trim();
               string city = strCity.ToString().Trim();                 
               hl.NavigateUrl = "KeywordSrchSumDtl.aspx?Keyword=" + keyword + "&Geo=" + geo                             + "&Site=" + site;
           }
           }
          }

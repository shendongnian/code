     void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
     {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          var hyperLink = (HyperLink)e.Item.FindControl("HyperLink1");
          hyperLink.NavigateUrl ="...."; 
          var checkBox = (CheckBox)e.Item.FindControl("CheckBox1");
          checkBox.Checked =....
          
        }
        
      }

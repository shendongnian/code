        void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
          {
        
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
              var button = new Button();
              button.CommandArgument = e.Row.DataItemIndex;
              button.CommandName="DownloadFile";         
              button.Text="Button";
              // COLUMN_INDEX where button shoud be
              e.Row.Cells[COLUMN_INDEX].Controls.Add(button);
             }
        
          }

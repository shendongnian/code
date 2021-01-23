      protected void RadGrid1_ColumnCreated(object sender, Telerik.WebControls.GridColumnCreatedEventArgs e)
      {
           if (e.Column.UniqueName == "ColumnName")
           {
               e.Column.Visible = false;
           }
      }
        
    

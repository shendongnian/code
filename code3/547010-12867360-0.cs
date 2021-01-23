    protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
    {
       try
       {
          var gridEditFormItem = (GridEditFormItem) e.Item;
    
          var txtAccountNumber = (TextBox)gridEditFormItem.FindControl("txtAccountNumber"); 
          var cbActive = (CheckBox)gridEditFormItem.FindControl("cbActive"); 
    
          // TODO: Check duplicate against database
    
          string SqlStr = "INSERT INTO [LBX_Portal_AccountNumbers] ([AccountNumber], [Site], [Active])" + 
            " VALUES ('" + txtAccountNumber.Text + "'" + ", '" + SiteName + "'" + ", '" + isActive + "')"; 
     
          SqlDataSource1.InsertCommand = SqlStr; 
          SqlDataSource1.Insert(); 
    
       }
       catch (Exception ex)
       {
          // Log Error
       }
    }
    
    protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
    {
       try
       {
          var gridEditFormItem = (GridEditFormItem) e.Item;
    
          int id = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"]);
          var txtAccountNumber = (TextBox)gridEditFormItem.FindControl("txtAccountNumber"); 
          var cbActive = (CheckBox)gridEditFormItem.FindControl("cbActive"); 
    
          // TODO: Check duplicate against database
    
          string SqlStr = "UPDATE [LBX_Portal_AccountNumbers] SET [AccountNumber] = '" + txtAccountNumber.Text + 
             "', [Active] = '" + isActive + "'  WHERE [ID] = " + lblID.Text; 
     
          SqlDataSource1.UpdateCommand = SqlStr; 
          SqlDataSource1.Update(); 
    
       }
       catch (Exception ex)
       {
          // Log Error
       }
    }

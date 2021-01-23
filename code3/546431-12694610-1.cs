    protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "PerformInsert")
        {
            GridEditFormItem gridEditFormItem = (GridEditFormItem)e.Item;
            Label lblID = (Label)gridEditFormItem.FindControl("lblID");
            TextBox txtAccountNumber = (TextBox)gridEditFormItem.FindControl("txtAccountNumber");
            CheckBox cbActive = (CheckBox)gridEditFormItem.FindControl("cbActive");
            bool isActive = false;
            if (cbActive.Checked)
                isActive = true;
            else
                isActive = false;
            string SqlStr = "INSERT INTO [LBX_Portal_AccountNumbers] ([AccountNumber], [Site], [Active])";
            SqlStr += " VALUES ('" + txtAccountNumber.Text + "'" + ", '" + SiteName + "'" + ", '" + isActive + "')";
            SqlDataSource1.InsertCommand = SqlStr;
            SqlDataSource1.Insert();
        }
        if (e.CommandName == "Update")
        {
            GridEditFormItem gridEditFormItem = (GridEditFormItem)e.Item;
            Label lblID = (Label)gridEditFormItem.FindControl("lblID");
            TextBox txtAccountNumber = (TextBox)gridEditFormItem.FindControl("txtAccountNumber");
            CheckBox cbActive = (CheckBox)gridEditFormItem.FindControl("cbActive");
            
            bool isActive = false;
            if (cbActive.Checked)
                isActive = true;
            else
                isActive = false;
            string SqlStr = "UPDATE [LBX_Portal_AccountNumbers] SET [AccountNumber] = '" + txtAccountNumber.Text;
            SqlStr += "', [Active] = '" + isActive + "'  WHERE [ID] = " + lblID.Text;
            SqlDataSource1.UpdateCommand = SqlStr;
            SqlDataSource1.Update();
        }
    }

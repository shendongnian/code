    //Verify and Update Record
    protected void UnverifiedSalesGV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        buttonCommand = e.CommandName;
        if (buttonCommand != "Cancel" && buttonCommand != "Edit" && buttonCommand != "Sort")
        {
            //Get Gridview data key and row index
            rowIndex = Convert.ToInt32(e.CommandArgument);
            salesID = UnverifiedSalesGV.DataKeys[rowIndex].Value.ToString();
            MessageLBL.Text = "";
            //Get productID 
            SalesData getSalesRecord = new SalesData();
            getSalesRecord.GetRowValuesSalesID(salesID);
            string productID = getSalesRecord.productID;
            if (buttonCommand == "VerifyRecord")
            {
                if (productID != "38")
                {
                    try
                    {
                        UpdateSalesRecordSDS.UpdateCommand = "UPDATE Sales SET Verified = @Verified WHERE ID = @ID";
                        UpdateSalesRecordSDS.UpdateParameters["ID"].DefaultValue = UnverifiedSalesGV.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                        UpdateSalesRecordSDS.UpdateParameters["Verified"].DefaultValue = true.ToString();
                        UpdateSalesRecordSDS.Update();
                        UnverifiedSalesGV.DataBind();
                        VerifiedSalesGV.DataBind();
                    }
                    catch (Exception ex)
                    {
                        MessageLBL.ForeColor = Color.Red;
                        MessageLBL.Text = "Could not verify sale. Message: " + ex.Message;
                    }
                }
                else
                {
                    //Get row index.
                    UnverifiedSalesGV.SetEditRow(rowIndex);
                    UnverifiedSalesGV.DataBind();
                    
                }
            }
            if (buttonCommand == "UpdateProduct")
            {
                DropDownList productValue = (DropDownList)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("RenewalProductDDL");
                if (productValue.SelectedIndex != 0)
                {
                    try
                    {
                        UpdateSalesRecordSDS.UpdateCommand = "UPDATE Sales SET ProductID = @ProductID, Verified = @Verified WHERE ID = @ID";
                        UpdateSalesRecordSDS.UpdateParameters["ID"].DefaultValue = UnverifiedSalesGV.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                        UpdateSalesRecordSDS.UpdateParameters["ProductID"].DefaultValue = productValue.SelectedValue;
                        UpdateSalesRecordSDS.UpdateParameters["Verified"].DefaultValue = true.ToString();
                        UpdateSalesRecordSDS.Update();
                        UnverifiedSalesGV.DataBind();
                        UnverifiedSalesGV.EditIndex = -1;
                        VerifiedSalesGV.DataBind();
                    }
                    catch (Exception ex)
                    {
                        MessageLBL.ForeColor = Color.Red;
                        MessageLBL.Text = "Could not verify sale. Message: " + ex.Message;
                    }
                }
                else
                {
                    MessageLBL.ForeColor = Color.Red;
                    MessageLBL.Text = "Please select renewal type.";
                }
            }
            if (buttonCommand == "UpdateRecord")
            {
                //Get date and user info
                DateTime getDate = System.DateTime.Now;
                MembershipUser user = Membership.GetUser();
                string activeuser = user.UserName;
                try
                {
                    //Get dropdown and textbox values
                    string amid;
                    string commisionMonth;
                    string grossSalesAmount;
                    string netSalesAmount;
                    string notes;
                    DropDownList accountManagerID = (DropDownList)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("AccountManagerDDL");
                    TextBox grossSalesValue = (TextBox)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("GrossSalesTXT");
                    TextBox netSalesValue = (TextBox)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("NetSalesTXT");
                    TextBox notesValue = (TextBox)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("NotesTXT");
                    DropDownList commissionMonthValue = (DropDownList)UnverifiedSalesGV.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("CommissionMonthDDL");
                    amid = accountManagerID.SelectedValue;
                    grossSalesAmount = grossSalesValue.Text;
                    netSalesAmount = netSalesValue.Text;
                    commisionMonth = commissionMonthValue.SelectedValue;
                    notes = notesValue.Text;
                    UnverifiedSalesSDS.UpdateCommand = "UPDATE [Sales] SET [OriginalAMID] = @OriginalAMID, [GrossSalesAmount] = @GrossSalesAmount, [NetSalesAmount] = @NetSalesAmount, [Notes] = @Notes, [CommissionMonth] = @CommissionMonth, [DateLastModified] = @DateLastModified, [UserLastModified] = @UserLastModified WHERE [ID] = @ID";
                    UnverifiedSalesSDS.UpdateParameters["OriginalAMID"].DefaultValue = amid;
                    UnverifiedSalesSDS.UpdateParameters["GrossSalesAmount"].DefaultValue = grossSalesAmount;
                    UnverifiedSalesSDS.UpdateParameters["NetSalesAmount"].DefaultValue = netSalesAmount;
                    UnverifiedSalesSDS.UpdateParameters["CommissionMonth"].DefaultValue = commisionMonth;
                    UnverifiedSalesSDS.UpdateParameters["Notes"].DefaultValue = notes;
                    UnverifiedSalesSDS.UpdateParameters["DateLastModified"].DefaultValue = getDate.ToString();
                    UnverifiedSalesSDS.UpdateParameters["UserLastModified"].DefaultValue = activeuser;
                    UnverifiedSalesSDS.UpdateParameters["ID"].DefaultValue = UnverifiedSalesGV.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    UnverifiedSalesSDS.Update();
                    UnverifiedSalesGV.DataBind();
                    UnverifiedSalesGV.EditIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageLBL.ForeColor = Color.Red;
                    MessageLBL.Text = "Could not update record. Message: " + ex.Message;
                }
            }
        }
    }
    //Hide and show fields
    protected void UnverifiedSalesGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == rowIndex)
        {
            string state = e.Row.RowState.ToString();
            if (state == "Alternate, Edit" || state == "Edit")
            {
                
                //Get record ID
                string salesID = UnverifiedSalesGV.DataKeys[Convert.ToInt32(e.Row.DataItemIndex)].Value.ToString();
                //Get productID 
                SalesData getSalesRecord = new SalesData();
                getSalesRecord.GetRowValuesSalesID(salesID);
                string productID = getSalesRecord.productID;
                if (productID == "38")
                {
                    //Items to Hide/Display
                    Button UpdateProductBTN = (Button)e.Row.FindControl("UpdateProductBTN");
                    Button UpdateBTN = (Button)e.Row.FindControl("UpdateBTN");
                    Label productLBL = (Label)e.Row.FindControl("CurrentProductLBL");
                    Label accountManagerLBL = (Label)e.Row.FindControl("AccountManagerLBL");
                    DropDownList productDDL = (DropDownList)e.Row.FindControl("RenewalProductDDL");
                    DropDownList accountManagerDDL = (DropDownList)e.Row.FindControl("AccountManagerDDL");
                    Label grossSalesLBL = (Label)e.Row.FindControl("GrossSalesLBL");
                    TextBox grossSalesTXT = (TextBox)e.Row.FindControl("GrossSalesTXT");
                    Label netSalesLBL = (Label)e.Row.FindControl("NetSalesLBL");
                    TextBox netSalesTXT = (TextBox)e.Row.FindControl("NetSalesTXT");
                    Label commissionMonthLBL = (Label)e.Row.FindControl("SalesCommissionLBL");
                    DropDownList commissionMonthDDL = (DropDownList)e.Row.FindControl("CommissionMonthDDL");
                    TextBox notesTXT = (TextBox)e.Row.FindControl("NotesTXT");
                    Label notesLBL = (Label)e.Row.FindControl("NotesLBL");
                    UpdateProductBTN.Visible = true;
                    UpdateBTN.Visible = false;
                    productLBL.Visible = false;
                    productDDL.Visible = true;
                    accountManagerLBL.Visible = true;
                    accountManagerDDL.Visible = false;
                    grossSalesLBL.Visible = true;
                    grossSalesTXT.Visible = false;
                    netSalesLBL.Visible = true;
                    netSalesTXT.Visible = false;
                    commissionMonthLBL.Visible = true;
                    commissionMonthDDL.Visible = false;
                    notesTXT.Visible = false;
                    notesLBL.Visible = true;
                }
            }
        }
    }

    protected void gwProfit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    if (ViewState["dtStartDate"] != null)
                 dtStartDate = (DataTable) ViewState["dtStartDate"];
            
            if (e.CommandName.Equals("Add"))
            {
                TextBox txtStartDate = (TextBox)gwProfit.FooterRow.FindControl("txtNewStartDate");
                TextBox txtEndDate = (TextBox)gwProfit.FooterRow.FindControl("txtNewEndDate");
                TextBox txtProfitPerUnit = (TextBox)gwProfit.FooterRow.FindControl("txtNewProfitPerUnit");
                if (txtEndDate.Text == "" || txtStartDate.Text == "" || txtProfitPerUnit.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please Select Start Date, End Date And Profit Per Unit.')", true);
                }
                else
                {
                    dtStartDate.Rows.Add(dtStartDate.NewRow());
                    dtStartDate.Rows[dtStartDate.Rows.Count - 1]["CurrencyDeatailID"] = -2;
                    dtStartDate.Rows[dtStartDate.Rows.Count - 1]["StartDate"] = objFunc.toDate(txtStartDate.Text);
                    dtStartDate.Rows[dtStartDate.Rows.Count - 1]["EndDate"] = objFunc.toDate(txtEndDate.Text);
                    dtStartDate.Rows[dtStartDate.Rows.Count - 1]["ProfitPerUnit"] = objFunc.toDecimal(txtProfitPerUnit.Text);
                    if (dtStartDate.Rows.Count >= 0&&dtStartDate.Rows[0]["CurrencyDeatailID"].ToString()=="-1")
                    {
                        dtStartDate.Rows[0].Delete();
                        if (dtStartDate.Rows.Count > 0 && dtStartDate.Rows[0].RowState == DataRowState.Deleted)
                            dtStartDate.Rows.RemoveAt(0);
                        
                    }
                    ViewState["dtStartDate"] = dtStartDate;
                    Profit_LoadGrid();
                }
            }
            else if (e.CommandName.Equals("Delete"))
            {
                int index = objFunc.toInt(e.CommandArgument.ToString());
                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RemoveAt = gvr.RowIndex;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["dtStartDate"];
                dt.Rows.RemoveAt(RemoveAt);
                dt.AcceptChanges();
                ViewState["dtStartDate"] = dt;
                Profit_LoadGrid();
            }
        }

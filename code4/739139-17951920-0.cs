      protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
            {
                 if (ddlLoanType.SelectedValue =="2")
                {
                    ddlDuration.Items.FindByValue("12").Enabled = false;
                    ddlDuration.Items.FindByValue("24").Enabled = false;
                  
                  
                }
            }

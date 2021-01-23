     if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Label lblRoleNo = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblRoleId");
                System.Web.UI.WebControls.Label lblSupervisorName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblSupervisorName");
                System.Web.UI.WebControls.Label lblUserECode = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblUserECode");
                System.Web.UI.WebControls.Label lblUserName = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblUserName");
                System.Web.UI.WebControls.Label lblDesignation = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblDesignation");
                System.Web.UI.WebControls.Label lblLDTraining = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblLDTraining");
                System.Web.UI.WebControls.Label lblNonProduction = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblNonProduction");
                System.Web.UI.WebControls.Label lblProcessSupport = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblProcessSupport");
                System.Web.UI.WebControls.Label lblProcessTraining = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblProcessTraining");
                System.Web.UI.WebControls.Label lblProduction = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblProduction");
                System.Web.UI.WebControls.Label lblSystemDowntime = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblSystemDowntime");
                System.Web.UI.WebControls.Label lblGrandTotal = (System.Web.UI.WebControls.Label)e.Row.FindControl("lblGrandTotal");
                //Checking weather Columns exist in the Pivot or not
                
                var dataRow = (DataRowView)e.Row.DataItem;
                var columnNameToCheck = "L & D Training%";
                var checkTraining = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase));
                if (checkTraining)
                {
                    // Property available
                    lblLDTraining.Text = (DataBinder.Eval(e.Row.DataItem, "L & D Training%")).ToString();
                }
                else
                {
                    lblLDTraining.Visible = false;
                }
                var columnNonProduction = "Non Production%";
                var checkNonProduction = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNonProduction, StringComparison.InvariantCultureIgnoreCase));
                if (checkNonProduction)
                {
                    // Property available
                    lblNonProduction.Text = (DataBinder.Eval(e.Row.DataItem, "Non Production%")).ToString();
                }
                else
                {
                    lblNonProduction.Visible = false;
                }
                var columnProcessSupport = "Process Support%";
                var checkProcessSupport = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnProcessSupport, StringComparison.InvariantCultureIgnoreCase));
                if (checkProcessSupport)
                {
                    // Property available
                    lblProcessSupport.Text = (DataBinder.Eval(e.Row.DataItem, "Process Support%")).ToString();
                }
                else
                {
                    lblProcessSupport.Visible = false;
                }
                var columnProcessTraining = "Process Training%";
                var checkProcesstraining = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnProcessTraining, StringComparison.InvariantCultureIgnoreCase));
                if (checkProcesstraining)
                {
                    // Property available
                    lblProcessTraining.Text = (DataBinder.Eval(e.Row.DataItem, "Process Training%")).ToString();
                }
                else
                {
                    lblProcessTraining.Visible = false;
                }
                var columnProduction = "Production%";
                var checkProduction = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnProduction, StringComparison.InvariantCultureIgnoreCase));
                if (checkProduction)
                {
                    // Property available
                    lblProduction.Text = (DataBinder.Eval(e.Row.DataItem, "Production%")).ToString();
                }
                else
                {
                    lblProduction.Visible = false;
                }
                var columnSystemDownTime = "System Downtime%";
                var checkSystemDownTime = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnSystemDownTime, StringComparison.InvariantCultureIgnoreCase));
                if (checkSystemDownTime)
                {
                    // Property available
                    lblSystemDowntime.Text = (DataBinder.Eval(e.Row.DataItem, "System Downtime%")).ToString();
                }
                else
                {
                    lblSystemDowntime.Visible = false;
                }
                var columnGrandTotal = "Grand Total%";
                var checkGrandTotal = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnGrandTotal, StringComparison.InvariantCultureIgnoreCase));
                if (checkGrandTotal)
                {
                    // Property available
                    lblGrandTotal.Text = (DataBinder.Eval(e.Row.DataItem, "Grand Total%")).ToString();
                }
                else
                {
                    lblGrandTotal.Visible = false;
                }
                
                var columnNameToCheckRoleID = "RoleId";
                var checkRoleID = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheckRoleID, StringComparison.InvariantCultureIgnoreCase));
                if (checkRoleID)
                {
                    // Property available
                    lblRoleNo.Text = (DataBinder.Eval(e.Row.DataItem, "RoleId")).ToString();
                }
                else
                {
                    lblRoleNo.Visible = false;
                }
                var columnNameToCheckSupervisorName = "SupervisorName";
                var checkSupervisorName = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheckSupervisorName, StringComparison.InvariantCultureIgnoreCase));
                if (checkSupervisorName)
                {
                    // Property available
                    lblSupervisorName.Text = (DataBinder.Eval(e.Row.DataItem, "SupervisorName")).ToString();
                }
                else
                {
                    lblSupervisorName.Visible = false;
                }
                var columnNameToCheckUserECode = "UserECode";
                var checkUserECode = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheckUserECode, StringComparison.InvariantCultureIgnoreCase));
                if (checkUserECode)
                {
                    // Property available
                    lblUserECode.Text = (DataBinder.Eval(e.Row.DataItem, "UserECode")).ToString();
                }
                else
                {
                    lblUserECode.Visible = false;
                }
                var columnNameToCheckUserName = "UserName";
                var checkUserName = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheckUserName, StringComparison.InvariantCultureIgnoreCase));
                if (checkUserName)
                {
                    // Property available
                    lblUserName.Text = (DataBinder.Eval(e.Row.DataItem, "UserName")).ToString();
                }
                else
                {
                    lblUserName.Visible = false;
                }
                var columnNameToCheckDesignation = "Designation";
                var checkDesignation = dataRow.Row.Table.Columns.Cast<DataColumn>().Any(x => x.ColumnName.Equals(columnNameToCheckDesignation, StringComparison.InvariantCultureIgnoreCase));
                if (checkDesignation)
                {
                    // Property available
                    lblDesignation.Text = (DataBinder.Eval(e.Row.DataItem, "Designation")).ToString();
                }
                else
                {
                    lblDesignation.Visible = false;
                }
                //Changing color of the Pivot Data
                if (Convert.ToInt32(lblRoleNo.Text.ToString()) == 2)
                {
                    e.Row.BackColor = System.Drawing.Color.GreenYellow;
                }
                if (Convert.ToInt32(lblRoleNo.Text.ToString()) == 3)
                {
                    e.Row.BackColor = System.Drawing.Color.Cyan;
                }
                if (Convert.ToInt32(lblRoleNo.Text.ToString()) == 4)
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                }
                if (Convert.ToInt32(lblRoleNo.Text.ToString()) == 5)
                {
                    e.Row.BackColor = System.Drawing.Color.Pink;
                }
                
            }

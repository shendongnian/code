     ddlstatus.Items.Clear();
     ddlperiority.Items.Clear();
     ddlusergroup.Items.Clear();
     ddldept.Items.Clear();
     foreach (DataRow dr in DS.Rows)
                {
                    txtemail.Enabled = false;
                    pan_addEdit.Visible = true;
                    this.btnSave.Text = "Update";
                    lbluserid.Text = Convert.ToString(dr["fdluserId"]);
                    txtuername.Text = Convert.ToString(dr["flduser"]);
                    txtPass.Text = Convert.ToString(dr["fldpass"]);
                    txtemail.Text = Convert.ToString(dr["fldemail"]);
                    ddlstatus.Items.Add ( Convert.ToString(dr["fldstatus"]));
                    ddlusergroup.Items.Add( Convert.ToString(dr["fldgroupId"]));
                    ddldept.Items.Add(  Convert.ToString(dr["flddept"]));
                    ddlperiority.Items.Add(  Convert.ToString(dr["fldperiority"]));
                }

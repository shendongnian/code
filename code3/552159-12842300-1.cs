            protected void OnCheckedChanged(object sender, EventArgs e)
        {
            //... Your code ...
            // Here we find the controls tha we will handle
            CheckBox chkAll = (GridView3.HeaderRow.FindControl("chkAll") as CheckBox);
            chkAll.Checked = true;
            foreach (GridViewRow row in GridView3.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox CheckBox1 = (CheckBox)row.FindControl("CheckBox1");
                    Label Label2 = (Label)row.FindControl("Label2");
                    TextBox TextBox1 = (TextBox)row.FindControl("TextBox1");
                    Button btnSave = (Button)row.FindControl("btnSave");
                    //GridView3.SetEditRow(row.RowIndex);
                    if (CheckBox1 != null)
                    {
                        if (CheckBox1.Checked)
                        {
                            if (TextBox1 != null && Label2 != null)
                            {
                                // Shows your "Edit Template"
                                btnSave.Visible = true;
                                Label2.Visible = false;
                                TextBox1.Visible = true;
                                TextBox1.Text = Label2.Text;
                            }
                        }
                    }
                }
            }
        }

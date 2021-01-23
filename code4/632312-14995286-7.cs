       protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            //Finiding checkbox control in gridview for particular row
            CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkdelete");
            //Condition to check checkbox selected or not
            if (chkdelete.Checked)
            {
                if (Session["reptable"] != null)
                {
                    string EmpID = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
                    DataTable dt1 = new DataTable();
                    dt1.Clear();
                    dt1 = Session["reptable"] as DataTable;
                    for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                    {
                        DataRow dr;
                        if (dt1.Rows[i][0].ToString() == EmpID)
                        {
                            dr = dt1.Rows[i];
                            dt1.Rows[i].Delete();
                            //dt1.Rows.Remove(dr);
                        }
                    }
                    //Session.Remove("reptable");
                    Session["reptable"] = dt1;
                }
                GridData();
            }
        }
    }

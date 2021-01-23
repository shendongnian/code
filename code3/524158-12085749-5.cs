    protected void gvstatus_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvstatus.EditIndex = -1;
            gvBind();
        }
     protected void gvstatus_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblmsg.Text = "";
            gvstatus.EditIndex = e.NewEditIndex;
            gvBind();
        }
    
      protected void gvstatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Add new record to database form girdview footer
            if (e.CommandName == "Add")
            {
                string empName = ((TextBox)gvstatus.FooterRow.FindControl("txtfempName")).Text;
                string empSalry = ((TextBox)gvstatus.FooterRow.FindControl("txtfempSalary")).Text;
                int result = InsertNewRecord(empName, empSalry);
                if (result > 0)
                {
                    lblmsg.Text = "Record is added successfully.";
                }
                gvstatus.EditIndex = -1;
                gvBind();
    
            }
        }
----------
        public void UpdateQuery(string empName, string empSalary, string lblID)
        {
            SqlCommand cmd = new SqlCommand("update myTable set empName='" + empName + "',empSalary='" + empSalary + "' where  id='" + lblID + "'", conn);
            conn.Open();
            int temp = cmd.ExecuteNonQuery();
            conn.Close();
            return temp;
        }
    
    
    public void InsertNewRecord(string empName, string empSalary)
        {
            SqlCommand cmd = new SqlCommand("your insert query ", conn);
            conn.Open();
            int temp = cmd.ExecuteNonQuery();
            conn.Close();
            return temp;
        }

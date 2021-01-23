    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
       GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)Gridview.Rows[index].FindControl("CheckBox1");
        string checkboxstatus;
        if (cb1.Checked == true)
            checkboxstatus = "YES";
        else if(cb1.Checked == false)
            checkboxstatus = "NO";
        //Here Write the code to connect to your database and update the status by 
        //sending the checkboxstatus as variable and update in the database.
    }

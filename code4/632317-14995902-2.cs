       protected void Button3_Click(object sender, EventArgs e)
            {
        for(int i = 0; i< GridView1.Rows; i++)
    {
    If((GridView1.Rows[i].FindControl("ckhdelete") as CheckBox) != null && (GridView1.Rows[i].FindControl("ckhdelete") as CheckBox).checked)
    {
    //Delete dataRow with EmpID = convertToInt( (GridView1.Rows[i].FindControl("ckhdelete") as CheckBox).value);
    }
    }
            }

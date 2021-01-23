     protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow oItem in GridView1.Rows)
        {
            string str1 = oItem.Cells[0].Text;
            string str2 = oItem.Cells[1].Text;
            string str3 = oItem.Cells[2].Text;
            insertData(str1, str2, str3);
        }
    }
    public void insertData(string str1,string str2,string str3)
    {
        SqlConnection cn = new SqlConnection("Your Connection strig");
        string sql = "insert into tbl1 (column1,column2,column3) values ('" + str1 + "','" + str2 + "','" + str3 + "')";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();
    }

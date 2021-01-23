    SqlConnection connStr = new SqlConnection
        ("Data Source=SERVER;Initial Catalog=HRPR;Persist Security Info=True;User ID=hr;Password=11");
    SqlCommand com;
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection connStr = new SqlConnection("Data Source=SERVER;Initial Catalog=HRPR;Persist Security Info=True;User ID=hr;Password=11");
        connStr.Open();
        foreach (GridViewRow g1 in GridView1.Rows)
        {
            com = new
            SqlCommand("INSERT INTO tblExmWrittn(column1,column2....)  VALUES( '" + g1.Cells(0).Value + "', '" + g1.Cells(1).Value + "' , '" + g1.Cells(2).Value + "' ,'" + g1.Cells(3).Value + "','" + g1.Cells(4).Value + "' ,'" + g1.Cells(5).Value + "','" + g1.Cells(6).Value + "')", connStr);
            com.ExecuteNonQuery();
            connStr.Close();
        }
        Label1.Text = "Records inserted successfully"; 
    }

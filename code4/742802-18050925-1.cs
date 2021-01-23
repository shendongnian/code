    SqlConnection connStr = new SqlConnection
        ("Data Source=SERVER;Initial Catalog=HRPR;Persist Security Info=True;User ID=hr;Password=11");
    SqlCommand com;
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection connStr = new SqlConnection("Data Source=SERVER;Initial Catalog=HRPR;Persist Security Info=True;User ID=hr;Password=11");
        connStr.Open();
        foreach (DataGridViewRow row in dataGridView.SelectedRows) 
        {
            com = new
            SqlCommand("INSERT INTO tblExmWrittn(column1,column2....)  VALUES( '" + row.Cells[0].Value.ToString(); + "', '" + row.Cells[1].Value.ToString();+ "' , '" + row.Cells[2].Value.ToString();+ "' ,'" + row.Cells[3].Value.ToString();+ "','" + row.Cells[4].Value.ToString();+ "' ,'" + row.Cells[5].Value.ToString();+ "','" + row.Cells[6].Value.ToString();+ "')", connStr);
            com.ExecuteNonQuery();
            connStr.Close();
        }
        Label1.Text = "Records inserted successfully"; 
    }

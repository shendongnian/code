    private void Query_Click(object sender, EventArgs e)
	{
		try
		{    
			MySqlConnection conn = new MySqlConnection(connectionString);
			conn.Open();
			da = new MySqlDataAdapter("SELECT * FROM books;", conn);
			ds = new DataSet();
			da.Fill(ds, sTable);
			conn.Close(); 
		}
		catch (MySql.Data.MySqlClient.MySqlException ex)
		{
			MessageBox.Show(ex.Message);			
		}
		finally
		{
			dataGridView1.Refresh();
			dataGridView1.DataSource = ds;
			dataGridView1.DataMember = sTable;
			
			if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
		}  
	}
	private void Update_Click(object sender, EventArgs e)
	{
		try
		{ 
			MySqlConnection conn = new MySqlConnection(connectionString);
			conn.Open();
			
			MySqlCommandBuilder cmb = new MySqlCommandBuilder(da);
			cmb.Connection = conn;
			da.Update(ds, sTable);
		}
		catch (MySql.Data.MySqlClient.MySqlException ex)
		{
			MessageBox.Show(ex.Message);			
		}
		finally
		{			
			if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
		}  
	}

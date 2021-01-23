	const string baza = "server=localhost;database=test;user=root;password=;";	
	private void button1_Click(object sender, EventArgs e)
	{
			
		using (MySqlConnection _conn = new MySqlConnection(baza))
		{
			using (MySqlCommand _comm = new  MySqlCommand())
			{
				_comm.Connection = _conn;
				_comm.CommandText = "SELECT IME,PREZIME FROM tabela";
				_comm.CommandType = CommandType.Text;
				
				using (MySqlDataAdapter _adapter = new MySqlDataAdapter(_comm))
				{
					DataTable _table = new DataTable;
					try
					{
						_adapter.Fill(_table);
						dataGridView1.DataSource = _table;
					}
					catch (MySqlException e)
					{
						MessageBox.Show(e.Message.ToString());
					}
				}
			}
		}
	}
	
		

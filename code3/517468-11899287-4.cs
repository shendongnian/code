        using(OleDbConnection connect = db.dbConnect())
        {
			try
			{
				connect.Open();
				//MessageBox.Show("Opened");
				using(OleDbCommand command = new OleDbCommand())
				{
					command.Connection = connect;
					command.CommandText = "SELECT * FROM Categories";
					using(IDataReader reader = command.ExecuteReader())
					{
						while(reader.Read())
						{
								cmbDisplay.Items.Add(reader.GetValue(reader.GetOrdinal("SeatNo"));
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("An erorr occured:" + ex);
			}        
        }

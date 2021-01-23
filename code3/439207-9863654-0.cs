    // Remove initialization of the SqlConnection in the form load event.
	private void button1_Click(object sender, EventArgs e)
	{
		using (SqlConnection con = new SqlConnection())
		{
			con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\myworkers.mdf;Integrated Security=True;User Instance=True";
			con.Open();
			// Optional: MessageBox.Show("OPEN!");
			int x;
			using (SqlCommand thiscommand = con.CreateCommand())
			{
				thiscommand.CommandText = "INSERT INTO player_info (player_id, player_name) values (10, 'Alex') ";
				x = thiscommand.ExecuteNonQuery();        /*I used variable x to verify that how many rows are affect, and the return is 1. The problem is that i dont see any changes in my table*/
				// Optional: MessageBox.Show(x.ToString());
			}
			con.Close();
		}
	}

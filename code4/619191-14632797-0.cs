		public bool rebateslip(int ticketID)
		{
			SqlCommand myCommand = new SqlCommand("SELECT ID FROM ticket WHERE ID = @ticketID", con);
			SqlDataAdapter sqlDa = new SqlDataAdapter(myCommand);
			myCommand.Parameters.AddWithValue("@ticketID", ticketID);
			return myCommand.ExecuteReader().HasRows;
		}
		public void createRebateslip(int ticketId)
		{
			SqlCommand myCommand = new SqlCommand("INSERT INTO RebateSlip (ticketId) VALUES (@ticketId); SELECT SCOPE_IDENTITY();", con);
			myCommand.Parameters.AddWithValue("@ticketId", ticketId);
			int insertID = (int)myCommand.ExecuteScalar();
			rebateSlipList.Add(new RebateSlip(insertID, ticketId));
		}

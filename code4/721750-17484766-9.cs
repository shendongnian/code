			// create and open a connection object
			SqlConnection conn = new SqlConnection("Data Source=(local);Integrated Security=True;Database=DDLYBank");
            try {
			conn.Open();
			// 1. create a command object identifying
			// the stored procedure
			SqlCommand cmd  = new SqlCommand("CreateNewFromHashValue", conn);
			// 2. set the command object so it knows
			// to execute a stored procedure
			cmd.CommandType = CommandType.StoredProcedure;
			// 3. add parameter to command, which
			// will be passed to the stored procedure
			cmd.Parameters.Add(new SqlParameter("@HashValue","YOUR HashValue"));
            cmd.Parameters.Add(new SqlParameter("@Debit",1)); // Your Debit,INT?
            cmd.Parameters.Add(new SqlParameter("@Balance",1)); // Your Balance ,INT?
            cmd.Parameters.Add(new SqlParameter("@Date",DateTime.Now)); // datetime :)
            cmd.Parameters.Add(new SqlParameter("@FingerPrint","FingerPrint")); // FingerPrint
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.ExecuteNonQuery();
            }
        } catch (Exception ex) {
            // NOT ONLY RETURN  HER !!! 
            Console.WriteLine(ex.Message.ToString());
        }
        //Remember to to close conn then you are done.
        conn.Close();

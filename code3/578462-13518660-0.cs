    using (var con = new SqlConnection())
    {
    	try
    	{
    		con.Open();
    		const string query = "INSERT INTO Sale (Name, Price) VALUES (@Name, @Price)";
    		using (var command = new SqlCommand(query, con))
    		{
    			foreach (var item in CheckBoxList1.Items.Cast<ListItem>().Where(item => item.Selected))
    			{
    				command.Parameters.Clear();
    				command.Parameters.AddWithValue("@Name", item.Text);
    				command.Parameters.AddWithValue("@Price", Convert.ToDecimal(TextBox3.Text));
    				command.ExecuteNonQuery();
    			}
    		}
    		con.Close();
    	}
    	catch (Exception)
    	{
    		Response.Write("<script>alert('Error While Input')</script>");
    	}
    }

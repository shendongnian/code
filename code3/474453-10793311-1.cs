    var code = Mcodeddl.SelectedItem.Text; // you may need to check Mcodeddl.SelectedItem != null here, if you not set default selected item 
    
    if (string.IsNullOrEmpty(code)) return; // return if code type empty, or show message. depending on your requirement
    
    using (SqlConnection connection = new SqlConnection(connectionString)) // using statement will dispose connection automatically
    {
        connection.Open();
    
        using (SqlCommand command = new SqlCommand("select Request_Type from dbo.component where Material_Code= @MaterialCode", connection))
        {
            command.Parameters.AddWithValue("@MaterialCode", code); // use parameters 
    
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var request = reader["Request_Type"];
                TextBox4.Text = request != DBNull.Value ? request.ToString().Trim() :string.Empty;// check null before ToString
            }
        }
    }
    }
    catch (Exception e)
    {
    Response.Write(e.Message);
    }

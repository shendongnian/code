    var code = Mcodeddl.SelectedItem.Text;
    
    if (string.IsNullOrEmpty(code)) return;
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        using (SqlCommand command = new SqlCommand("select Request_Type from dbo.component where Material_Code= @MaterialCode", connection))
        {
            command.Parameters.AddWithValue("@MaterialCode", code);
    
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var request = reader["Request_Type"];
                TextBox4.Text = request != DBNull.Value ? request.ToString().Trim() : string.Empty;
            }
        }
    }
    }
    catch (Exception e)
    {
    Response.Write(e.Message);
    }

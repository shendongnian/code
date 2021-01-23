            string query = "INSERT INTO [LocationInfo]([LocationIP], [LocationName])" +
                           "VALUES (@locIP, @locName)";
            SqlCommand cmd = new SqlCommand(query, sqlcon_QOEMetrices);
            cmd.Parameters.AddWithValue("@locIP", TextBox2.Text);
            cmd.Parameters.AddWithValue("@locName", TextBox3.Text);        
            try
            {
                sqlcon_QOEMetrices.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlcon_QOEMetrices.Close();
            }

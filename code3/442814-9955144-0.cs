            string query = "INSERT INTO desg VALUES (@txtsno, @txtdesg, @txtbasic)";
            SqlCommand cmd = new SqlCommand(query, sqlcon_QOEMetrices);
            cmd.Parameters.AddWithValue("@txtsno", txtsno.Text);
            cmd.Parameters.AddWithValue("@txtdesg", txtdesg.Text);
            cmd.Parameters.AddWithValue("@txtbasic", txtbasic.Text);
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

        private void btnToSQL_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(local)\sqlexpress;Initial Catalog=rTALIS;Integrated Security=True";
            var cn = new SqlConnection(connStr);
            var cm = new SqlCommand("exec usp_InsertRecord", cn);
            cm.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cn.Open();
                foreach (Row r in rows)
                {
                    cm.Parameters.Clear();
                    cm.Parameters.AddWithValue("@Number1", r.Number1);
                    cm.Parameters.AddWithValue("@Number2", r.Number2);
                    cm.Parameters.AddWithValue("@Number3", r.Number3);
                    cm.Parameters.AddWithValue("@Number4", r.Number4);
                    cm.Parameters.AddWithValue("@Number5", r.Number5);
                    cm.Parameters.AddWithValue("@Number6", r.Number6);
                    cm.Parameters.AddWithValue("@Number7", r.Number7);
                    cm.Parameters.AddWithValue("@Date1", r.Date1);
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

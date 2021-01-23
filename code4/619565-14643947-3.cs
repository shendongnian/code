    private void ThemTramBT_Click(object sender, EventArgs e)
    {
        string conn = "Data Source=USER-PC;Initial Catalog=NCKHmoi;Integrated Security=True";
        using (SqlConnection connect = new SqlConnection(conn))
        {
            using (SqlCommand command = new SqlCommand("ThemTram", conn))
            {
                connect.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Ten", SqlDbType.NVarChar, 50).Value = KhuVucComboBox.Text;
                command.Parameters.Add("@TenTinh", SqlDbType.NVarChar, 50).Value = TinhComboBox.Text;
                command.Parameters.Add("@TenTram", SqlDbType.NVarChar, 50).Value = ThemTramTB.Text;
                command.Parameters.AddWithValue("@KhuVucID", DBNull.Value); //need to pass even if not used
                command.Parameters.AddWithValue("@TinhID", DBNull.Value); //need to pass even if not used
                command.ExecuteNonQuery();
            }
        }
    }

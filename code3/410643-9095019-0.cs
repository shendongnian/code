    public DataTable askSQL (string sqlQuestion)
    {
        DataTable table = new DataTable();
        try
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuestion, connector))
            {
                adapter.Fill(table);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("Fel vid anslutningen!" + e);
        }
    }
			

    public SaveComboBoxContent()
    {
        string SQL = "INSERT INTO info2 (name_id) VALUES (@name_id)"
        using (var cn = new SqlConnection(CONNECTION_STRING))
        {
            using(var cmd = new SqlCommand(SQL, cn))
            {
                cmd.Parameters.AddWithValue("@name_id", comboBox1.SelectedValue)
                cn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    // Do some logging or something. 
                    MessageBox.Show("There was an error accessing your data. DETAIL: " + e.ToString());
                }
            }
        }
    }

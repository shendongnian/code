    conn.Open();
    string qry = "UPDATE clickStream SET clickCount = (clickCount + 1) WHERE linkName = 'mainServiceButton';SELECT @@ROWCOUNT;";
    SqlCommand cmd = new SqlCommand(qry, conn);
    try
    {
        int rowsAffected = (int)cmd.ExecuteScalar();
        if (rowsAffected != 1)
            throw new ApplicationException("Rows affected should be 1, " + rowsAffected + " were affected.");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Not executed successfully, exception: " + ex.ToString());
    }
    conn.Close();

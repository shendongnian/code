    try
    {
        conn.Open();
    }
    catch(SqlCeException ex)
    {
        // output the error to see what's going on
        MessageBox.Show(ex.Message); 
    }

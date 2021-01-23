        try
        {
            clsMain.con.Open();
            cmd.ExecuteNonQuery();
            clsMain.con.Close();
        }
        catch (Exception ex)
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
            MessageBox.Show(ex.Message);
        }

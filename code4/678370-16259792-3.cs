        try
        {
            clsMain.con.Open();
            cmd.ExecuteNonQuery();
            clsMain.con.Close();
        }
        catch (Exception ex)
        {
            if (clsMain.con.State != ConnectionState.Closed)
                clsMain.con.Close();
            MessageBox.Show(ex.Message);
        }

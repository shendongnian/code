    public SqlConnection SqlSaverConn()
    {
        string path = Application.StartupPath + "\\";
        String conStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename="+ path +"SMS_DB.mdf;Integrated Security=True;User Instance=True";
        SqlConnection con = new SqlConnection(conStr);
        try
        {
            con.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        return con;
    }

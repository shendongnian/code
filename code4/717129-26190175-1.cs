    private void Form2_Load(object sender, EventArgs e)
    {
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        crConnectionInfo.ServerName = "SQL Server Database";
        crConnectionInfo.DatabaseName = "my_testConnection";
        crConnectionInfo.UserID = "sa";
        crConnectionInfo.Password = "123";
    }

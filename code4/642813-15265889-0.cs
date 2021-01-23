    label3.Text = "Connecting...";
    button1.Enabled = false;
    var bkw = new BackgroundWorker();
    bkw.DoWork += (s, ev) =>
        {
            ev.Result = ssc.isConnectable(ssc.makeConnectionString(
                            SqlServerConnParamters.SqlServerIPAddress,
                            SqlServerConnParamters.AccountValidationDatabaseName,
                            SqlServerConnParamters.SqlServerUserName,
                            SqlServerConnParamters.SqlServerPassword, 5));
        };
    
    bkw.RunWorkerCompleted += (s, ev) =>
        {
            if ((bool)ev.Result == true)
            {
                label3.Text = "Connected";
                button1.Enabled = true;
            }
            else
            {
                label3.Text = "Database connection failed";
            }
    
            bkw.Dispose();
        };
    
    bkw.RunWorkerAsync();

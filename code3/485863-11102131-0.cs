    static void Main()
    {
        #if DEBUG
        connection = "sqlserver://localhost;integratedSecurity=true;";
        #else
        connection = GlobalFields.MainTableAdapter.Connection;
        #endif
        GlobalFields.OrdersAdapter.Connection = connection;
        connection.Open(); // I get an SqlException with no details if the 
                           // machine is connected (probably caused by a timeout)
        Application.Run(new frmLogin());
    }

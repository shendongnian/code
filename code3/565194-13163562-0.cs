    private Connection myConnection;
    private Statement myStatement;
    private ResultSet myResultSet;
    String databaseURL = "http://www.boehnecamp.com/phpMyAdmin/razorsql_mysql_bridge.php";
    public Form1()
    {
        InitializeComponent();
        loadAccountNumbers();
    }
    //load account numbers to ComboBox
    private void loadAccountNumbers()
    {
        SQL sql = new SQL();
        using (myConnection = sql.getConnection(databaseURL))
        using (myStatement = myConnection.createStatement(databaseURL))
        using (myResultSet = myStatement.executeQuery("SELECT accountNumber FROM accountInformation"))
        {
            // add account numbers to ComboBox
            while (myResultSet.next())
                accountNumberComboBox.Items.Add(myResultSet.getString("accountNumber"));
        }
    }

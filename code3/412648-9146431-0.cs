    string connectionStringTemplate = "server={0};database={1};Trusted_Connection=Yes;persist security info=False;connection timeout=500";
    foreach (string DatabaseConfig in DataHoldingClass.Server_Database_Config) {
      // is this string parsing really necessary - why not separate variables?
      string[] splitConfig = DatabaseConfig.Split('|'); 
      // 0=database and 1=server, apparently from above
      string connectionString = String.Format(connectionStringTemplate, splitConfig[1], splitConfig[0]); 
      using (SqlConnection cn = new SqlConnection(connectionString)) {
        //do some work here
      }
    }

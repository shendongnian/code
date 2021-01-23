     <connectionStrings>
        <add name="MySQLConnectionString" connectionString="server=localhost;User      Id=root;pwd=;database=data1;" providerName="MySql.Data.MySqlClient"/>
      </connectionStrings>
    
    -----------------------
    using MySql.Data.MySqlClient;
    ...
    MySqlConnection Conn = new MySqlConnection();
    Conn = new MySqlConnection(ConnStr);

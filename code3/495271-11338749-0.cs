    public void UpdateDatabase()
            {
                System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection();
                conn.ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.5.144)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl)));UID=mwm;PWD=mwm";
                conn.Open();
                OracleCommand command = conn.CreateCommand();
                command.CommandText = strParam1;
                command.ExecuteNonQuery();
                command.Dispose();
            }

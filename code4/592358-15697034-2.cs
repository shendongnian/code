    [DllImport("odbc32.dll")]
            internal static extern int SQLDataSources(long EnvHandle, long Direction, StringBuilder ServerName, long ServerNameBufferLenIn,
                ref long ServerNameBufferLenOut, StringBuilder Driver, long DriverBufferLenIn, ref long DriverBufferLenOut);
    
            [DllImport("odbc32.dll")]
            internal static extern int SQLAllocEnv(ref long EnvHandle);
    
            //[DllImport("odbc32.dll")]
            //internal static extern int SQLDataSources(int EnvHandle, int Direction, StringBuilder ServerName, int ServerNameBufferLenIn,
            //    ref int ServerNameBufferLenOut, StringBuilder Driver, int DriverBufferLenIn, ref int DriverBufferLenOut);
    
            //[DllImport("odbc32.dll")]
            //internal static extern int SQLAllocEnv(ref int EnvHandle);
    
            public static List<ODBC_System_DSN_Entry> ListODBCsources()
            {
                List<ODBC_System_DSN_Entry> entries = new List<ODBC_System_DSN_Entry>();
    
                long envHandle = 0;
                const long SQL_FETCH_NEXT = 1;
                const long SQL_FETCH_FIRST_SYSTEM = 32;
    
                if (SQLAllocEnv(ref envHandle) != -1)
                {
                    long ret;
                    StringBuilder serverName = new StringBuilder(1024);
                    StringBuilder driverName = new StringBuilder(1024);
                    long snLen = 0;
                    long driverLen = 0;
                    ret = SQLDataSources(envHandle, SQL_FETCH_FIRST_SYSTEM, serverName, serverName.Capacity, ref snLen,
                                driverName, driverName.Capacity, ref driverLen);
                    while (ret == 0)
                    {
                        //System.Windows.Forms.MessageBox.Show(serverName + System.Environment.NewLine + driverName);
                        entries.Add(new ODBC_System_DSN_Entry(serverName.ToString(), driverName.ToString()));
                        ret = SQLDataSources(envHandle, SQL_FETCH_NEXT, serverName, serverName.Capacity, ref snLen,
                                driverName, driverName.Capacity, ref driverLen);
                    }
                    return entries;
                }
                return null;
            }
    
            public struct ODBC_System_DSN_Entry
            {
                internal String _server;
                internal String _driver;
    
                internal ODBC_System_DSN_Entry(String server, String driver)
                {
                    _server = server;
                    _driver = driver;
                }
    
                public String Server { get { return _server; } }
                public String Driver { get { return _driver; } }
            }

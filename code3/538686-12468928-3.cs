    static bool _quit = false;
    Thread thxMonitor = new Thread(MonitorQueue);
    void StartThread() {
        thxMonitor.Start();
    }
    
    void MonitorQueue(object obj) {
        var conn = new SqlConnection(connString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "WAITFOR (RECEIVE CONVERT(int, message_body) AS Message FROM SBQ) TIMEOUT 500";
        var dataTable = new DataTable();    
        while(!quit && !dataTable.AsEnumerable().Any()) {
            using (var da = new SqlDataAdapter(command)) {    
                da.Fill(dataTable);
            }
        }
    }
    
    void KillThreadByAnyMeansNecessary() {
        _quit = true;
    }

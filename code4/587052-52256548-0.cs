    public DateTime getServerTime()
    {
        workcalendar2Entities1 db = new workcalendar2Entities1();
        var con = db.Database.Connection;
        var cmd = con.CreateCommand();
        cmd.CommandText = "SELECT SYSDATETIME()";
        con.Open();
        var datetime = (DateTime)cmd.ExecuteScalar();
        con.Close();
        return datetime;
    }

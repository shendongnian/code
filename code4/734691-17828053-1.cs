    using(var myCon = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["mySQLCon"]))
    using(var cmd = new MySqlCommand("insert into PMduedates(eCId,ECClass,ddate,PMType) values(eCId,ECClass,ddate,PMType)", myCon))
    {
        cmd.InsertCommand.Parameters.Add("eCId", MySqlDbType.VarChar, 20, "eqpID");
        cmd.InsertCommand.Parameters.Add("ECClass", MySqlDbType.VarChar, 100, "class");
        cmd.InsertCommand.Parameters.Add("ddate", MySqlDbType.VarChar, 100, "MaintType");
        cmd.InsertCommand.Parameters.Add("PMType", MySqlDbType.Date, 10, "Duedate");
        myCon.Open();
        int countInserted = cmd.ExecuteNonQuery();
    } // using closes the connection implicitely

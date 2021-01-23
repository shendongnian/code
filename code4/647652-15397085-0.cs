    private string CreateInsertStatement(double time_began_5, double time_finished_5)
    {
       string sql = "INSERT INTO Slots ([Date],[RoomID],";
       string valuesql = " Values (@date,@room,";
       for (double Time = time_began_5; Time < time_finished_5; Time = Time + 0.5)
       {
        string Time1 = Time.ToString("0.00");
        sql+ = "[" + Time1 + "],";
        valuesql+ = "1,";
       }
       sql = sql.TrimEnd(',') + ") ";
       valuesql = valuesql.TrimEnd(',') + ") ";
    
       return sql + valuesql;
    }

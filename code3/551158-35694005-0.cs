       strin sql= "insert into Emp_table (SL_NO,empane,empid,salaray) values(:SL_NO,:empane,:empid,:salary)";
        OracleCommand command = new OracleCommand(sql, connection)
        command.Parameters.Add(new OracleParameter("SL_NO", 1);
        command.Parameters.Add(new OracleParameter("empane", "sree"));
        command.Parameters.Add(new OracleParameter(("empid", 1002));
        command.Parameters.Add(new OracleParameter(("salaray", 20000));
        command.Connection.Open();
        command.ExecuteNonQuery();
        command.Connection.Close();

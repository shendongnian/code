            // without voodoo
            
            OracleCommand ncmd = new OracleCommand("select nvl(max(MYFIELD),0) from mytable", conn);
 
            ncmd.CommandType = CommandType.Text;
 
            object r = ncmd.ExecuteScalar();
 
            Console.WriteLine("a: " + r);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // with the voodoo
 
            ncmd.CommandText = "begin select nvl(max(MYFIELD),0) into :maxvalue from mytable; end;";
            ncmd.CommandType = CommandType.Text;
 
            OracleParameter res = new OracleParameter(":res", OracleDbType.Double);
            res.Direction = ParameterDirection.ReturnValue;
            ncmd.Parameters.Add(res);
 
            ncmd.ExecuteNonQuery();
 
            Console.WriteLine("b: " + res.Value);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

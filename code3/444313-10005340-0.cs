     OracleConnection con = new OracleConnection();
    
                //using connection string attributes to connect to Oracle Database
                con.ConnectionString = "User Id="+userId+";Password="+password+";Data Source="+schema;
                
               
                OracleCommand ocb = new OracleCommand("dbms_utility.compile_schema", con);
                ocb.CommandType = CommandType.StoredProcedure;
                ocb.Parameters.Add(new OracleParameter("@schema", userId));
                con.Open();
                ocb.ExecuteNonQuery(); 
                Console.WriteLine("Connected to Oracle" + con.ServerVersion);
                // Close and Dispose OracleConnection object
                con.Close();
                con.Dispose();
                Console.WriteLine("Disconnected");

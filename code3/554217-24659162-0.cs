    SqlCeConnection con = new SqlCeConnection(@"Data ource=C:\Users\MyComputer\Documents\Visual Studio 2012\Projects\ConsoleApplication4\ConsoleApplication4\Database1.sdf");
                con.Open();
    
            string sql = "SELECT * FROM Employee";//select query
            string sql1 = "INSERT INTO Employee(Name, Age)VALUES('aaa', 12)";//insert query
                   
                    SqlCeCommand cmd = new SqlCeCommand(sql, con);
                    SqlCeCommand cmd1 = new SqlCeCommand(sql1, con);
                    cmd1.ExecuteScalar(); // executing insert command
                    SqlCeDataReader reader = cmd.ExecuteReader();//to read data from table
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", reader[0],reader[1]));
                    }
                   con.Close();
                   

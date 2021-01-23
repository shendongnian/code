    using (OleDbConnection con = new OleDbConnection(@"Network Library=dbmssocn;Data Source=sourcename,1655;database=Oracle;User id=sysadm;Password=password;")
    {
        con.Open();
        using (OleDbCommand cmd = con.CreateCommand() )
        {
            cmd.CommandText = "SELECT * FROM SYSADM.PS_RQ_DEFECT_NOTE where ROW_ADDED_OPRID = 'github'";
            
            using(IDataReader thisReader = cmd.ExecuteReader() )
            {
                while (thisReader.Read())
                {
                    Console.WriteLine(thisReader["fieldname"]);
                    Console.ReadKey();
                }
            }
        };
    }
    catch (SqlException e)
    {
        Console.WriteLine(e.Message);
    }

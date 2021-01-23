    Console.WriteLine("Enter table name:");
    Console.Write(">> ");
    string tblname = Console.ReadLine();
    string sql = String.Format("insert into {0} (time, date, pin) values ... ", tblname);
    SqlCommand com = new SqlCommand(sql, con);                    
    ...

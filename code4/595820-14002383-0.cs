    CREATE TABLE patients 
         (patientid AUTOINCREMENT PRIMARY KEY, 
         firstlastname CHAR(15), 
         birthdate CHAR(10), 
         birthplace CHAR(8), 
         gender CHAR(1), 
         bloodtype CHAR(4), 
         telnum CHAR(12), 
         address CHAR(255))
    ......
    string info = "Huseyin Sabirli 13/11/1978 Nicosia MBRh+ 05333768275 " + 
                  "Kelebek Street, No:11, Taskinkoy, Nicosia, KKTC";
    string name = info.Substring(0, 15);
    string date = info.Substring(16, 11)
    string place = info.Substring(27, 8);
    string blood = info.Substring(37, 4);
    string num = info.Substring(41, 12);
    string address = info.Substring(53);
    string cmdText = "INSERT INTO patients (" +
                     "firstlastname, birthdate, birthplace, bloodtype, telnum, address) " +
                     "VALUES (?,?,?,?,?,?)"
    using(OleDbConnection cn = getConnection())
    {
        cn.Open();
        using(OleDbCommand cmd = new OleDbCommand(cmdText, cn))
        {
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Parameters.AddWithValue("place", place);
            cmd.Parameters.AddWithValue("blood", blood);
            cmd.Parameters.AddWithValue("num", num);
            cmd.Parameters.AddWithValue("address", address);
            cmd.ExecuteNonQuery();
        }
    }

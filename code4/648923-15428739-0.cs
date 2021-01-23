    MySqlConnection myConn = new MySqlConnection(connStr);
    
    string sqlStr = "SELECT CONCAT(Name, ' ', Score) as NameAndScore " + 
                    "FROM highscore ORDER BY Score DESC";
    
    MySqlDataAdapter dAdapter = new MySqlDataAdapter(sqlStr, myConn);
    DataTable dTable = new DataTable();
    dAdapter.Fill(dTable);
    dAdapter.Dispose();
    lstNames.DisplayMember = "NameAndScore";
    lstNames.ValueMember = "NameAndScore";
    lstNames.DataSource = dTable;
    lstNames.DataBind();

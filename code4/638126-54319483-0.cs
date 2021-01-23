    string con= "SERVER=localhost; user id=root; password=; database=dbname";
    
    MySqlConnection connect = new MySqlConnection(con);
    connect.Open();
    try
    {
    string sqlQuery = "SELECT * FROM DATA WHERE date(date) = date(now())";
    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, connect);
    DataTable ds = new DataTable();
    da.Fill(ds);
    Datagrid.DataSource = ds;
    }
    catch(Exception ex)
    {
    Console.WriteLine(ex.ToString());
    }
   

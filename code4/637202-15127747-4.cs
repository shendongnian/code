    using namespace System.Data.SqlClient;
    
    SqlConnection con = new SqlConnection("Data source = [ip]; Initial catalog = [db name]; User id = [user name]; password = [password]");
    
    con.Open();

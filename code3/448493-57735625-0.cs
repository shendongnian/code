var connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword";
using (var con = new SqlConnection(connectionString))
{
    con.Open();
    var sql = "Sql query";
    using (var cmd =new SqlCommand(sql, con))
    {
    	cmd.CommandTimeout = 10;
    }
}

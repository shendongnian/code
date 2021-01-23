    SqlConnection c = new SqlConnection(@"Data Source=GILBERTB-PC\SQLEXPRESS;Initial Catalog=DVDandGameBooking;Integrated Security=True");
    string queryString = "SELECT * From DVD where Id = @id";
    var paramId = new SqlParameter("id", SqlDbType.VarChar);
    var query = new SqlCommand(queryString, c);
    query.Parameters.Add(paramId);

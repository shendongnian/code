    string MyPageTitle="MyPageTitle"; // your page title here
    string myConnectionString = "connectionstring"; //you connectionstring goes here
    
    SqlCommand cmd= new SqlCommand("select Price from Tickets where ConcertName ='" + MyPageTitle.Replace("'","''") + "'" , new SqlConnection(myConnectionString));
    cmd.Connection.Open();
    labelPrice.Text= cmd.ExecuteScalar().ToString(); // assign to your label
    cmd.Connection.Close();

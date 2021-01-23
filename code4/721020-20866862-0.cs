    <!-- language: c# -->
    public List&lt;PersonalUser> FetchMyData()
    {
    
        SqlConnection Conn = new SqlConnection(@"Data Source=rex;Initial Catalog=PersonalDetails;Integrated Security=True");
        SqlCommand Comm1 = new SqlCommand("Select Name, Address, TelephoneNo,Date From PersonalUsers order by Name", Conn);
        
        Conn.Open();
        SqlDataReader DR1 = Comm1.ExecuteReader();
        
        var result = new List&lt;PersonalUser>();
        while (DR1.Read())
        {
            result.Add(new PersonalUser {
                Name = DR1.GetString(0);
                Address= DR1.GetString(1);
                TelephoneNo = DR1.GetString(2);
                Date = DR1.GetString(3)
              }
           );
        }
        
        
        return result;
    }

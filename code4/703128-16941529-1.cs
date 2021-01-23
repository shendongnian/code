    using (SqlConnection con = new SqlConnection("Data Source=GATE-PC\\SQLEXPRESS;Initial Catalog=dbProfile;Integrated Security=True"))
    {
        con.Open();
        using (SqlCommand cmdd = new SqlCommand("select * from Profile where user_Id = @userid AND RegNo = @reg", con))
        {
            ...
            using (SqlDataReader reader = cmdd.ExecuteReader())
            {
                ...
            }
        }
    }

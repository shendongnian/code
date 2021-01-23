    DataTable dt = new DataTable(); 
    using(SqlConnection con = new SqlConnection("server=localhost;user=armin;password=root;"))
    {
        using(SqlCommand result = new SqlCommand(
                "SELECT userid FROM KDDData.dbo.userprofile order by userid", con))
        {
            con.Open(); 
            using(SqlDataReader reader = result.ExecuteReader())
            {
               dt.Load(reader); 
               List<string> userids = new List<string>(dt.Rows.Count); 
               foreach (DataRow item in dt.Rows) 
               { 
                  userids.Add(item.ItemArray[0].ToString().Trim()); 
               }
            } 
            DataTable temp = new DataTable(); 
            foreach (string user in userids) 
            { 
                using(SqlCommand result1 = new SqlCommand( 
                "select itemid from KDDTrain.dbo.train where userid=" + user, con))
                {
                    using(SqlDataReader reader1 = result1.ExecuteReader())
                    {
                        if (!reader1.HasRows)   continue; 
                        temp.Load(reader1); 
                    }
                } 
            } 
       }

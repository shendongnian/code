    using (SqlConnection c= new SqlConnection(cs))
    {
        string s= "select * from Doctor"; //remove the for xml
    
        using (SqlCommand cmd = new SqlCommand(s,c))
        {
             using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
             {
                DataTable dt;
                ad.Fill(dt); 
                
                //Use DataTable.WriteXml() method 
                //dt.WriteXml(parameters);
             }
        }
    }

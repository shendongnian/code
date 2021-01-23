    using (SqlConnection myconnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString))
    {
        using (SqlCommand sqlCmd1 = new SqlCommand(salequery, myconnection1))
        {
            using (SqlDataAdapter ad1 = new SqlDataAdapter(sqlCmd1))
            {
                dt1 = new DataTable();
                ad1.Fill(dt1);
            }
        }
    }

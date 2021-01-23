    using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection())
    {
        ...
        using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand())
        {
            ...
            using (System.Data.SqlClient.SqlDataReader reader = new System.Data.SqlClient.SqlDataReader())
            {
                //DO STUFF
            }
        }
    }

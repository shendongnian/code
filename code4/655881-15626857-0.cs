    Object o;
    using (SqlConnection sql = GetSqlConnection) {
        using (SqlCommand sqlCommand = GetSqlCommand()) {
            using (Datareader dr = GetDataReader()) {
                Object o = new Object();
                while (dr.read()) {
                    //do something
                }
            }
            if (o == null) // RESHARPER SAYS THAT THIS WILL ALWAYS BE TRUE
                //do something
        }
    }

    using (SqlConnection conn = new SqlConnection(connString)) {
        using (StreamWriter s = new StreamWriter(UdFil)) {
            while (Reader.Read()) {
               ....
            }
        }
    }

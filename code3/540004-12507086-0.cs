    public static class Connection
        {
            private static SqlConnection sqlconn;
            public static SqlConnection getconnection() {
                if (sqlconn==null)
                   sqlconn = new SqlConnection("Connectionsting.");
                return sqlconn;
            }
    
            
        }

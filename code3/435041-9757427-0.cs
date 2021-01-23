            public static DataSet  login_vald()
            {
                DBConnect myConnection = new DBConnect();
                SqlCommand comm = new SqlCommand("ph.validate_app_user", myConnection.connection);
                comm.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(ds); //missing argument from SqlDataAdapter this will fill the ds
               return ds; //return filled DataSet
            }

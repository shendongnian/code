            SqlConnection ok = new SqlConnection(ConfigurationManager.ConnectionStrings["TempConnection"].ConnectionString);
            SqlDataAdapter cmd = new SqlDataAdapter("select * from ChallanOrder", ok);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            return dt;
        }
           
    }

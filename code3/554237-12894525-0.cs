            DataSet ds = new DataSet() ;
            
            SqlConnection Con = new SqlConnection("Data Source=UrDB;Initial Catalog=es_NG;Persist Security Info=True;User ID=sa;Password=;Connection Timeout=600");
           // SqlConnection Con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Test;User ID=;Password=;Connection Timeout=600");
            Con.Open();
            string SqlQry = "select top 100 first_name,last_name,email_address  from user";
            SqlDataAdapter da = new SqlDataAdapter(SqlQry, Con); 
            DataTable dtTbl = new DataTable();
            da.Fill(dtTbl);            

     SqlCommand cmd = new SqlCommand("select * from yourtable", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            { 
                string value=dr[0].ToString();
                if (value == "yourcondition")
                {              
                    SqlCommand cmd2 = new SqlCommand("delete from yourtable where columnname ='"+value+"'", con2);
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                }
            } dr.Close();
            con.Close();

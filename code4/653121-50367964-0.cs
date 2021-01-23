            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from info", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            Console.WriteLine(dt.Columns[0].ColumnName.ToString());
            Console.WriteLine(dt.Rows[1].ItemArray[0].ToString());

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from info", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            ad.Fill(dt);
            Console.WriteLine(dt.Tables[0].Columns[0].ColumnName.ToString());
            Console.WriteLine(dt.Tables[0].Rows[0].ItemArray[0].ToString());

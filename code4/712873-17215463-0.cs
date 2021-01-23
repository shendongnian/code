            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand command = new SqlCommand("select * from vw_Haber_Baslik_Ozet", con);
            SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                String colName = dc.ColumnName;
                String valueOfCol1 = ds.Tables[0].Rows[0][dc.ColumnName].ToString();
            }
            con.Close();

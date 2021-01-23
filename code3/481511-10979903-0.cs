     SqlCommand cmd = new SqlCommand("select * from assessmenttest", con);
            SqlDataAdapter adptr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adptr.Fill(ds, "test");
            int[] arr = new int[10];
            DataTable table = ds.Tables[0];
            test.agree = new int[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                test.agree[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["option1"]);
            }

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Name");
            dt.Columns.Add("designation");
            dt.Columns.Add("age");
            dt.Columns.Add("year");
            string[] lines = File.ReadAllLines(@"C:\Users\user1\Desktop\text1.txt", Encoding.UTF8);
            string[] lines1 = File.ReadAllLines(@"C:\Users\user2\Desktop\text1.txt", Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                DataRow dr = dt.NewRow();
                dr["Name"] = values[0].ToString();
                dr["designation"] = values[1].ToString();
                dr["age"] = values[2].ToString();
                dr["year"] = values[3].ToString();
                dt.Rows.Add(dr);
            }
            foreach (string line in lines1)
            {
                string[] values = line.Split(',');
                DataRow dr = dt.NewRow();
                dr["Name"] = values[0].ToString();
                dr["designation"] = values[1].ToString();
                dr["age"] = values[2].ToString();
                dr["year"] = values[3].ToString();
                dt.Rows.Add(dr);
            }
            grdstudents.DataSource = dt;
            grdstudents.DataBind();
        }

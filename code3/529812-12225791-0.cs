            DataTable dt = GetData();
            dt.Columns.Add("RollNo1", typeof(Int32));
            foreach (DataRow item in dt.Rows)
            {
                item["RollNo1"] = item["RollNo"];
            }
            dt.DefaultView.Sort = "RollNo1";
            dt.Columns.Remove("RollNo");
            dataGridView1.DataSource = dt;

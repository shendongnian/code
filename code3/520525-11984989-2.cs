            private void button1_Click(object sender, EventArgs e)
            {
                Dictionary<string, double[]> dict = new Dictionary<string, double[]>();
                dict.Add("1", new double[] { 1.10, 1.20 });
                dict.Add("2", new double[] { 2.10, 2.20 });
                dict.Add("3", new double[] { 3.10, 3.20 });
                dict.Add("4", new double[] { 4.10, 4.20 });
                dict.Add("5", new double[] { 5.10, 5.20 });
    
                dataGridView1.DataSource = Dictionary2Table(dict);
            }
    
            public DataTable Dictionary2Table(Dictionary<string, double[]> dict)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("key", typeof(string));
                dt.Columns.Add("Value1", typeof(double));
                dt.Columns.Add("Value2", typeof(double));
                dict
                    .Select(i => new { Key = i.Key, Val1 = i.Value[0], Val2 = i.Value[1] })
                    .ToList()
                    .ForEach(i=>dt.Rows.Add(i.Key,i.Val1,i.Val2));
                return dt;
            }

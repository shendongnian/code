        List<Row> rows = new List<Row>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //var rows = new List<Row>();  //limited scope
            var sr = new StreamReader(@"C:\so_test.txt");
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (!String.IsNullOrEmpty(s.Trim()))
                {
                    rows.Add(new Row(s));
                }
            }
            sr.Close();
            dataGridView1.DataSource = rows;
        }

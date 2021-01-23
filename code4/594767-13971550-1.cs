        protected void readfile_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Row No.");
            table.Columns.Add("Col No.");
            table.Columns.Add("Width");
            table.Columns.Add("Height");
            table.Columns.Add("Image URL");
            table.Columns.Add("Description");
            using (StreamReader sr = new StreamReader(@"D:\Temp\fileread\readtext.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split(',');
                    table.Rows.Add(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                }
            }
            MyGridView.DataSource = table;
            MyGridView.DataBind();
        }

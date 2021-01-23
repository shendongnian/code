        protected void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetTable();
            dataGridView2.DataSource = GetTable();
            dataGridView3.DataSource = GetTable();
        }
        private DataTable GetTable()
        {
            DataTable table = new DataTable();
            for (int i = 0; i < 6; i++)
            {
                table.Columns.Add("Col" + i.ToString(), typeof(string));
            }
            for (int i = 0; i < 1000; i++)
            {
                table.Rows.Add(GetRandomString(), GetRandomString(), GetRandomString(), GetRandomString(), GetRandomString(), GetRandomString());
            }
            return table;
        }
        private Random rand = new Random();
        private string validChars = "0123456789abcdefghijklmnopqurstuvwyz";
        private string GetRandomString()
        {
            StringBuilder builder = new StringBuilder();
            char[] c = new char[rand.Next(15, 20)];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = validChars[rand.Next(0, validChars.Length - 1)];
            }
            return new string(c);
        }

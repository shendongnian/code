       public DataTable GetData()
        {
            DataTable t = new DataTable();
            t.Columns.Add("FirstName", typeof(string));
            t.Columns.Add("LastName", typeof(string));
            t.Rows.Add("Joe","Bloggs");
            t.Rows.Add("Fred","Bloggs");
            return t;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            DataTable people = GetData();
            peopleBindingSource.DataSource = people;
            
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            DataTable t = peopleBindingSource.DataSource as DataTable;
        }

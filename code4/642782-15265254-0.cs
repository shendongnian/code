        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Import Status");
            listView1.Columns.Add("Price");
            listView1.Columns.Add("Date");      
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem LVI = new ListViewItem(txtstatus.Text);
            LVI.SubItems.Add(txtPrice.Text);
            LVI.SubItems.Add(txtDate.Text);
            listView1.Items.Add(LVI);
        }

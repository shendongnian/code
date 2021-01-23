        DataGridView dgv = new DataGridView(); 
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("C_" + table.Columns.Count);
            table.Rows.Add("R1");
            table.Rows.Add("R2");
            dgv.DataSource = table;
            DataGridViewButtonColumn oCol = new DataGridViewButtonColumn();
            oCol.Name = "Buttons";
            oCol.Text = "(...)";
            oCol.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(oCol);
            Controls.Add(dgv); //<--Try to check this.
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dgv.Columns.Clear();
        }

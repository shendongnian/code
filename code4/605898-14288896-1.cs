        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1 = new DataGridView(); //<-- uncommenting this line breaks the form's dgv from displaying anything
            //dataGridView1.Columns.Clear(); //<-- This is what I actually needed to clear the control
            DataTable table = new DataTable();
            table.Columns.Add("C_" + table.Columns.Count);
            table.Rows.Add("R1");
            table.Rows.Add("R2");
            dataGridView1.DataSource = table;
            DataGridViewButtonColumn oCol = new DataGridViewButtonColumn();
            oCol.Name = "Buttons";
            oCol.Text = "(...)";
            oCol.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(oCol);
            Controls.Add(dataGridView1); //<-- try to check this one
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }

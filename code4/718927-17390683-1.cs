     Class1 c = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            c.firstName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            c.lastName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

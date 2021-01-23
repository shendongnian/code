    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
     form2 f2 = new form2();
     f2.label1.Text = dataGridView1.SelectedCells[0].Value.ToString();
     f2.ShowDialog();
     dataGridView1.SelectedCells[0].Value = f2.textBox1.Text;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

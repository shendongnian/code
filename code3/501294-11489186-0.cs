    void textBox1_KeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) {
            label2.Text = textBox1.Text;
            label2.Text = "Movies released before " + textBox1.Text;
        }
    }

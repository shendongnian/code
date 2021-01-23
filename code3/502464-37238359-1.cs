    private void PictureBox1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Click Sukses");
    }
    private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            this.PictureBox1_Click(sender, e); //or try this one "this.PictureBox1_Click(sender, AcceptButton);"
        }
    }

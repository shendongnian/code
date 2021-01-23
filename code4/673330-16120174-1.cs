    private void Undo_Click(object sender, EventArgs e)
    {
        textBox1.Undo();
    }
     
    private void Cut_Click(object sender, EventArgs e)
    {
        textBox1.Cut();
    }
     
    private void Copy_Click(object sender, EventArgs e)
    {
        textBox1.Copy();
    }
     
    private void Paste_Click(object sender, EventArgs e)
    {
        textBox1.Paste();
    }
     
    private void Delete_Click(object sender, EventArgs e)
    {
        int SelectionIndex = textBox1.SelectionStart;
        int SelectionCount = textBox1.SelectionLength;
        textBox1.Text = textBox1.Text.Remove(SelectionIndex, SelectionCount);
        textBox1.SelectionStart = SelectionIndex;
    }
     
    private void SelectAll_Click(object sender, EventArgs e)
    {
        textBox1.SelectAll();
    }
     
    private void Font_Click(object sender, EventArgs e)
    {
        FontDialog fontDialog = new FontDialog();
        if (fontDialog.ShowDialog() == DialogResult.OK)
        {
            textBox1.Font = fontDialog.Font;
        }
    }
     
    private void Forecolor_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            textBox1.ForeColor = colorDialog.Color;
        }
    }
     
    private void Backcolor_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            textBox1.BackColor = colorDialog.Color;
        }
    }

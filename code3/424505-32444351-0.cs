    private void comboBox1_KeyDown(object sender, KeyEventArgs e)
    {
        CheckCaretPosition();
    }
    
    private void comboBox1_MouseDown(object sender, MouseEventArgs e)
    {
        CheckCaretPosition();
    }
    private void comboBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if((Control.MouseButtons | MouseButtons.Left) != 0)
            CheckCaretPosition();
    }
    
    private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        CheckCaretPosition();
    }
    
    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
        CheckCaretPosition();
    }
    
    void CheckCaretPosition()
    {
        int caretPosition = comboBox1.SelectionStart;
        Debug.WriteLine(caretPosition);
    }

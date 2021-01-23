    void TextBox1_TextChanged(object s, EventArgs arg)
    {
        MessageBox.Show(arg.HashCode.ToString());
    }
    void HandleEvent()
    {
        TextBox1.TextChanged += TextBox1_TextChanged;
    }

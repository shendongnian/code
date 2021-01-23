    List<TextBox> _textBoxes = new List<TextBox>();
    int _nextTextBoxTop = 15;
    private void AddTextBox(string initialText)
    {
        var tb = new TextBox();
        tb.Name = "tb" + _textBoxes.Count;
        _textBoxes.Add(tb);
        tb.Location = new Point(120, _nextTextBoxTop);
        _nextTextBoxTop += 36;
        tb.Size = new Size(80, 30);
        tb.Text = initialText;
        tb.TextChanged += TextBox_TextChanged
        grBox1.Controls.Add(tb);
    }
    static void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        string s = tb.Text;
        ...
    }    

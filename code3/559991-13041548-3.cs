    string _Text = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text;
    _Text = _Text.Replace("pc", "Personal Computer"); // Replace pc with Personal Computer
    if (_Text != new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text)
    {
    new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd).Text = _Text; // Change the current text to _Text
    }

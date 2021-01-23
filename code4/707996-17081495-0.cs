    textBox.OnTextChanged += (EventArgs e) => // invoked on every text change
    {
        var lines = myTextBox.Where(x.Length > 5); // Get the long lines
        for (var i; i < lines.Count(); i++)  // iterate over long lines
        {
            lines[i] = lines[i].Substring(0, 5); // replace the line with its substring(stripped) value
        }
    }
    

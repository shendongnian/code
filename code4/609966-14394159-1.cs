    string[] parts = quality.Split('+');
    Regex regex = new Regex(@"^""(.*)""$");
    var textBoxes = Controls.OfType<TextBox>().ToList();
    
    for (int i = 0; i < parts.Length; i++)
    {
        string part = parts[i].Trim();
    
        var match = regex.Match(part);
        if (match.Success)
        {
            parts[i] = match.Groups[1].Value;
            continue;
        }
    
        var textBox = textBoxes.FirstOrDefault(tb => tb.Name + ".Text" == part);
        if (textBox != null) // possibly its an error if textbox not found
            parts[i] = textBox.Text; 
    }    
    
    mainTextBox.Text = String.Join(" ", parts);

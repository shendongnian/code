    var lines = System.IO.File.ReadAllLines(@"d:\test.txt");
    
    foreach (var line in lines)
    {
        var words = line.Split(' ');
        if (words.Length > 1)
            words[0] = words[1];
    }
    
    richTextBox3.Text = string.Join(Environment.NewLine, lines);

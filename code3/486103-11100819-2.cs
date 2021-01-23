    var blocks = text.Split("Entry #");
    foreach (var block in blocks)
    {
        // removing the line with the entry number
        block = block.Substring(block.IndexOf(Environment.NewLine));
        // removing the empty lines
        block = block.Trim('\n', '\r');
        
        // add your processing here
    }

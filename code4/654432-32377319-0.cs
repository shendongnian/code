        string text = "This is a line.\nThis is another line.";
        IList<string> lines = text.Split(new string[] { @"\n" }, StringSplitOptions.None);
        
        TextBlock tb = new TextBlock();
        foreach (string line in lines)
        {
            tb.Inlines.Add(line);
            tb.Inlines.Add(new LineBreak());
        }

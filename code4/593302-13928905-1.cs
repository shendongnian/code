    string[] replaceStrings = txtUnwanted.Text.Split(',');
    List<string> lines = new List<string>(textBox1.Lines);
    for (int i = 0; i < lines.Count; i++)
        foreach (string repl in replaceStrings)
            lines[i] = lines[i].Replace(repl, "");

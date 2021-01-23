    StreamWriter writer = null;
    Dictionary<string, string> replacements = new Dictionary<string, string>();
    replacements.Add("ID2", "NewValue2");
    // ... further replacement entries ...
    using (writer = File.CreateText("output.txt"))
    {
        foreach (string line in File.ReadLines("input.txt"))
        {
            bool replacementMade = false;
            foreach (var replacement in replacements)
            {
                if (line.StartsWith(replacement.Key))
                {
                    writer.WriteLine(string.Format("{0}   :{1}",
                        replacement.Key, replacement.Value));
                    replacementMade = true;
                    break;
                }
            }
            if (!replacementMade)
            {
                writer.WriteLine(line);
            }
        }
    }
                
    File.Replace("output.txt", "input.txt", "input.bak");

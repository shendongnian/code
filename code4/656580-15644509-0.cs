    string[] lines = System.IO.File.ReadAllLines(input_file);
    for (int i = 0; i < lines.Length; i++)
    {
        string line = lines[i];
        line = line.Replace("ý", "\\t");
        int n = line.Split(new string[] { "\\t" }, StringSplitOptions.None).Count()-1;
        string[] temp = new string[4 - n ];
        temp = temp.Select(input => "\\t").ToArray();
        line += string.Join(string.Empty, temp);
        lines[i] = line;
    }
    System.IO.File.WriteAllLines(output_file, lines);

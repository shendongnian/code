    string[] lines = File.ReadAllLines(txtProxyListPath.Text);
    List<string> list_lines = new List<string>(lines);
    Parallel.ForEach(list_lines, line =>
    {
        //Your stuff
    });

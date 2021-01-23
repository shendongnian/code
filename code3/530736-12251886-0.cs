    string[] lines = File.ReadAllLines(txtProxyListPath.Text);
    // No need for the list
    // List<string> list_lines = new List<string>(lines); 
    Parallel.ForEach(lines, line =>
    {
        //My Stuff
    });

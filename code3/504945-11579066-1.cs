    public void SplitCSV(string input)
    {
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
    
        foreach (Match match in csvSplit.Matches(input))
        {
            Console.WriteLine(match.Value.TrimStart(','));
        }
    }
    
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        SplitCSV("111,222,\"33,44,55\",666,\"77,88\",\"99\"");
    }

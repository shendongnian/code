    Regex regx = new Regex("<.*?>");  
    private void FunctionTwo(string input)
        {
            Match m = regx.Match(input);
            var results = new List<string>();
            while (m.Success)
            {
                results.Add(m.Value);
                m = m.NextMatch();
            }
        }

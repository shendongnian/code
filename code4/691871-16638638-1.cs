    private void FunctionTwo(string input)
        {
            Regex regx = new Regex("<.*?>");      
            Match m = regx.Match(input);
            var results = new List<string>();
            while (m.Success)
            {
                results.Add(m.Value);
                m = m.NextMatch();
            }
        }

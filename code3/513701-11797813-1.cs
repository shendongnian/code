    public List<string> SplitCSV(string input, List<string> line)
        {
            Regex csvSplit = new Regex("(([^,^\'])*(\'.*\')*([^,^\'])*)(,|$)", RegexOptions.Compiled);
            
            foreach (Match match in csvSplit.Matches(input))
            {
                line.Add(match.Value.TrimStart(','));
            }
            return line; 
        }

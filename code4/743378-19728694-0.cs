    public List<string> Seach(string word)
    {
        List<string> results = new List<string>();
        foreach(var node in nodeIndex[word[0]])
        {
            List<string> nodeResults = new List<string>();
            this.DoSearch(node, 0, new StringBuilder(word), nodeResults);
            foreach(var nodeResult in nodeResults)
            {
                var text = string.Format("{0}{1}",node.Parent.Text, nodeResult);
                results.Add(node.Parent.Text, nodeResult);
            }
        }
        return results.Distinct().ToList();
    }

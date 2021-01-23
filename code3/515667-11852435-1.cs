    public IEnumerable<int> getAscendingValues(IEnumerable<int> source)
    {
        List<int> output = new List<int>();
    
        foreach (int next in source)
        {
            if (output.Count == 0 || output.Last() < next)
            {
                output.Add(next);
            }
            else
            {
                if (output.Count <= 1)
                {
                    output.Clear();
                }
                else
                {
                    return output;
                }
            }
        }
    
        if (output.Count > 1)
        {
            return output;
        }
        else
        {
            return null; //could also return an empty enumeration
        }
    }

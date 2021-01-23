    class DecisionMatrix
    {
        List<Decision> decisions;
        Decision Find(byte input)
        {
            return decisions.Find(d => d.IsMatch(input));
        }
    }

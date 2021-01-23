    private class NonCollidingFloatComparer : IComparer<float>
    {
        public int Compare(float left, float right)
        {
            return (right > left) ? 1 : -1; // no zeroes 
        }
    }
    
    // silly method for the sake of demonstration
    public void sortNodes(List<Node> nodesToSort)
    {
        SortedDictionary<float, Node> nodesByWeight = new SortedDictionary<float, Node>(new NonCollidingFloatComparer());
        foreach (Node n in nodesToSort)
        {
            nodesByWeight.Add(n.FloatKey, n);
        }
        foreach (Node n in nodesByWeight.Values)
        {
            Console.WriteLine(n.FloatKey + " : " + n.UniqueID);
        }
    }

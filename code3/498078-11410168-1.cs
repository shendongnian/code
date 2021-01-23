    private static List<int> WeightsJuggle(List<int> packages, IOrderedEnumerable<int> weights, int weight)
    {
        if (weight == 0)
            return packages;
    
        foreach (int i in weights)
        {
            if(i > weight)
            {
                packages.Add(i);
                return packages;
            }
        }
    
        packages.Add(weights.Max());
        return WeightsJuggle(packages, weights, weight - weights.Max());
    }

    private static Random rnd = new Random();
    public static IEnumerable<int> getRandomNumbers(int count, int lowerbound, int upperbound, int specialNumber = int.MinValue, int specialNumberCount = int.MinValue)
    {
        var list = new List<int>(count);
        var specialNumPositions = new Dictionary<int, int>();
        if (specialNumberCount > 0)
        {
            // generate random positions
            for (int i = 0; i < specialNumberCount; i++)
            {
                int nextPos = rnd.Next(lowerbound, upperbound + 1);
                while(specialNumPositions.ContainsKey(nextPos))
                    nextPos = rnd.Next(lowerbound, upperbound + 1);
                specialNumPositions.Add(nextPos, i);
            }
        }
        while (list.Count < count)
        {
            int next = rnd.Next(lowerbound, upperbound + 1);
            if(specialNumberCount == int.MinValue || !specialNumPositions.ContainsKey(list.Count))
            {
                list.Add(next);
            }
            else  
            {
                list.Add(specialNumber);
            }
        }
        return list;
    }

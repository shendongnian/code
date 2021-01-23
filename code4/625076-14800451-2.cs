    private static Random rnd = new Random();
    public static IEnumerable<int> getRandomNumbers(int count, int lowerbound, int upperbound, int specialNumber = int.MinValue, int specialNumberCount = int.MinValue)
    {
        List<int> list = new List<int>(count);
        HashSet<int> specialNumPositions = new HashSet<int>();
        if (specialNumberCount > 0)
        {
            // generate random positions for the number that must be creates n-times
            for (int i = 0; i < specialNumberCount; i++)
            {
                while (!specialNumPositions.Add(rnd.Next(0, count)))
                    ;
            }
        }
        while (list.Count < count)
        {
            if (specialNumPositions.Contains(list.Count))
                list.Add(specialNumber);
            else
                list.Add(rnd.Next(lowerbound, upperbound + 1));
        }
        return list;
    }

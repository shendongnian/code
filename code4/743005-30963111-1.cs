    public static int GetDuplicatesCount(List<int> listA, List<int> listB)
    {
        var tempB = new HashSet<int>(listB);
        var result = 0;
        foreach (var item in listA)
        {
            if (tempB.Contains(item))
            {
                result++;
            }
        }
        return result;
    }

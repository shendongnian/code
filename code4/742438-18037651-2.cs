    public static bool ContainsSequence<T>(this List<T> outer, List<T> inner)
    {
        var innerCount = inner.Count;
        for (int i = 0; i < outer.Count - innerCount; i++)
        {
            bool isMatch = true;
            for (int x = 0; x < innerCount; x++)
            {
                if (!outer[i + x].Equals(inner[x]))
                {
                    isMatch = false;
                    break;
                }
            }
            if (isMatch) return true;
        }
        return false;
    }
     

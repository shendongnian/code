    public static List<int> GenNumbers(String input, int count, int maxNum)
    {
        List<int> ret = new List<int>();
        Random r = new Random(input.GetHashCode());
        for (int i = 0; i < count; ++i)
        {
            int next = r.Next(maxNum - i);
            foreach (int picked in ret.OrderBy(x => x))
            {
                if (picked <= next)
                    ++next;
                else
                    break;
            }
            ret.Add(next);
        }
        return ret;
    }

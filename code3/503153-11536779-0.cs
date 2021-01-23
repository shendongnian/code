    void MultiSet(List<string> elems, int last, int n, ref List<string> set, ref List<List<string>> result)
    {
        if (set.Count < n)
        {
            for (int index = last; index < elems.Count; index++)
            {
                set.Add(elems[index]);
                MultiSet(elems, index, n, ref set, ref result);
                set.RemoveAt(set.Count - 1);
            }
        }
        else
        {
            result.Add(new List<string>(set));
        }
    }
    List<List<string>> PowerMultiSet(List<string> elems, int n)
    {
        var result = new List<List<string>>();
        var set = new List<string>();
        MultiSet(elems, 0, n, ref set, ref result);
        return result;
    }

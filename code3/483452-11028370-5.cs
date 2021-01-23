    private List<string[]> GetDiff(List<string[]> listA, list<string[] listB>)
    {
        var diff = new List<string[]>();
        foreach (var a in listA)
        {
            bool found = false;
            foreach (var b in listB)
            {
                if (a.SequenceEqual(b))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                diff.Add(a);
            }
        }
        foreach (var b in listB)
        {
            bool found = false;
            foreach (var a in listA)
            {
                if (b.SequenceEqual(a))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                diff.Add(b);
            }
        }
        return diff;
    }

    public a Traverse(List<q> qs, string id)
    {
        foreach (var q in qs)
        {
            foreach (var a in q._as)
            {
                if (a.Id == id)
                    return a;
                else
                    return Traverse(a.qs, id);
            }
        }
        return null;
    }

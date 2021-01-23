    private IEnumerable<Group> EnumerateChilds(Group parent)
    {
        if (parent.Groups != null)
        {
            foreach (var g in parent.Groups)
            {
                yield return g;
                foreach (var sub in EnumerateChilds(g))
                {
                    yield return sub;
                }
            }
        }
    }

    private IEnumerable<Group> EnumerateChildren(Group parent)
    {
        if (parent.Groups != null)
        {
            foreach (var g in parent.Groups)
            {
                yield return g;
                foreach (var sub in EnumerateChildren(g))
                {
                    yield return sub;
                }
            }
        }
    }

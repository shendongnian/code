    public IEnumerable<ParentObject> GetParents(WebApplication webApp)
    {
        // assumes webApp.Parents uses deferred execution.
        return webApp.Parents;
    }
    public void ProcessParent(WebApplication webApp)
    {
        foreach (ParentObject p in GetParents())
        {
            using(p)
            {
                foreach (ChildObject o in p.ChildObjects)
                {
                    using(o)
                    {
                         // do something with o
                    }
                }
            }
        }
    }
}

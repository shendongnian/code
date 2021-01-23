    public IEnumerable<ParentObject> GetParents(WebApplication webApp)
    {
        // assumes webApp.Parents uses deferred execution.
        return webApp.Parents;
    }
    public void ProcessParent(WebApplication webApp)
    {
        foreach (ParentObject p in GetParents())
        {
            // Assumes p.Dipsose() calls ChildObject.Dispose() for all p.ChildObjects.
            using(p)
            {
                foreach (ChildObject o in p.ChildObjects)
                {
                    // do something with o
                }
            }
        }
    }
}

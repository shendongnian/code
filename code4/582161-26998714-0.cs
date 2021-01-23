    public IEnumerable<MyObject> GetMyObjectsForId(string id)
    {
        using (var ctxt = new RcContext())
        {
            // causes an error
            return ctxt.MyObjects.Where(x => x.MyObjects.Id == id);
        }
    }

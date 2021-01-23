    public IEnumerable<MyObject> GetMyObjectsForId(string id)
    {
        using (var ctxt = new RcContext())
        {
            return ctxt.MyObjects.Where(x => x.MyObjects.Id == id).ToList();
        }
    }

    public List<Obj> GetObjs() {
        if (GetObjs() == null)
        {
            SetObjs(new List<Obj>());
        }
        if (GetObjs().Count < 1)
        {
            GetObjs().Add(new Obj());
        }
        return GetObjs();
    }

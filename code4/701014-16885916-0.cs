    private List<Obj> objs;
    public List<Obj> Objs
    {
        get
        {
            if (objs == null)
            {
                objs = new List<Obj>();
            }
            if (objs.Count < 1)
            {
                objs.Add(new Obj());
            }
            return objs;
        }
        set { objs = value; }
    } 

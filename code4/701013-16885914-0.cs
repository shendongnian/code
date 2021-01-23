    private List<Obj> _objs;
    public List<Obj> Objs
    {
        get { 
        if (_objs== null)
        {
            _objs = new List<Obj>();
        }
        if (_objs.Count < 1)
        {
            _objs.Add(new Obj());
        }
        return _objs;
     }
        set { _objs= value; }
    }

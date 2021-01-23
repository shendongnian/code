    Dictionary<eTypeVar, Type> _Types = new Dictionary<eTypeVar, Type> {
        { eTypeVar.Int, typeof(Int32) },
        { eTypeVar.Char, typeof(Char) },
        { eTypeVar.Float, typeof(Single) }
    };
    
    public Boolean Check(eTypeVar type, Object value)
    {
        return value.GetType() == _Types[type];
    }

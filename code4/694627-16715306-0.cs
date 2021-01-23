    public override void Work(ObjBase o)
    {
        base.Work(o);
        var a = o as ObjA;
        if (a != null)
        {
            // do a-specific things
        }
    }

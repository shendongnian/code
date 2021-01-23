    One one = new One();
    Base bp = one.GetBase(2);
    
    if (bp is BasePlusOne)
    {
        BasePlusOne b = (BasePlusOne)bp;
        b.Bp1MEthod();
        b.FuncA();
    }

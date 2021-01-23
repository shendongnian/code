    public override void CalcV(IV iv, int index = -1)
    {
        ....
        double v = index > -1 ? GetV(a,b,c, index) : GetV(a,b,c);
    
        ....
    }

    public override void CalcV(IV iv)
    {
        CalcV(iv, null);
    }
    
    public override void CalcV(IV iv, int? index)
    {
         //snip
         double v = index.HasValue ? GetV(a,b,c,index.Value) : GetV(a,b,c);
         //snip
    }

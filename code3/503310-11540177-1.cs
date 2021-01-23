    public IEnumerable<IResult> DoStuffIndependently()
    {
       yield return This;
       yield return That;
    }
    
    public IEnumerable<IResult> DoStuffBeforeSometimes()
    {
       yield return AffectThis;
       yield return AffectThat;
       foreach (var x in DoStuffIndependently())
            yield return x;
    }

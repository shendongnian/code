    public long Test_PossibleLambdaImpl()
    {
        var units2 = GetUnits();
        var stopWatch2 = new Stopwatch();
        stopWatch2.Start();
        MyUnit item2;
        var possibleLambdaImpl = new PossibleLambdaImpl();
        foreach (MyUnit unit in units2)
        {
            if (possibleLambdaImpl.Comparison(unit))
            {
                item2 = unit;
                break;
            }
        }
        return stopWatch2.ElapsedMilliseconds;
    }

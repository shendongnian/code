    public void Go()
    {
        // warmup
        Test_Equality();
        Test_Lambda();
    
        // timed tests
        Console.WriteLine(Test_Equality() + " ms");
        Console.WriteLine(Test_Lambda() + " ms");
    }
    
    public long Test_Lambda()
    {
        var units1 = GetUnits();
        var stopWatch1 = new Stopwatch();
        stopWatch1.Start();
        MyUnit item1 = units1.testme<MyUnit>(u => u.Id == 999999);
        return stopWatch1.ElapsedMilliseconds;
    }
    
    public long Test_Equality()
    {
        var units2 = GetUnits();
        var stopWatch2 = new Stopwatch();
        stopWatch2.Start();
        MyUnit item2;
        foreach (MyUnit unit in units2)
        {
            if (unit.Id == 999999)
            {
                item2 = unit;
                break;
            }
        }
    
        return stopWatch2.ElapsedMilliseconds;
    }

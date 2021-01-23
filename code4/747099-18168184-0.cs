    // Create a local copy of N and M, so that if we update 
    // it elsewhere it doesn't affect the closure
    var n = N;
    var m = M;
    Parallel.For(0, m, i =>
    {
        double d;
        try
        {
            d = Double.Parse(lData[i]);
        }
        catch (Exception)
        {
            throw new Exception("Wrong formatting on data number " + (i + 1) + " on line " + (lCount + 1));
        }
        sg[lCount % n][i] = d;
    });

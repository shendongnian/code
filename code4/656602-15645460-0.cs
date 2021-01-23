    public void DoSomething(int a, int b)
    {
        Trace.TraceInformation("Starting to do something: a = {0}, b = {1}",
            a, b);
        try 
        {
            int c = a / b;
        }
        catch (DivideByZeroException e)
        {
            Debug.WriteLine("OH NO ... 'b' WAS ZERO!!!! RUN AWAY!!!!");
            throw e;
        }
        Trace.TraceInformation("Done doing something");
    }

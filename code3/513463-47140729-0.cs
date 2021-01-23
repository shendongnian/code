    public static void Main(string[] args)
    {
        if (args != null && !args.Any()) // Any() doesn't like nulls
        {
            // No parameters passed.
            ComputeNoParam cptern = new ComputeNoParam();
            cptern.ComputeWithoutParameters();
            return;
        }
    
        // process parameters
        ComputeParam cpter = new ComputeParam();
        foreach (string s in args){...}
    }

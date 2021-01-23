    public static void Main(string[] args)
    {
        if (!args?.Any() ?? true)
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

    public void M(dynamic x)
    {
        MImpl(x);
    }
    private void MImpl(int x)
    {
        Console.WriteLine("M(int)");
    }
    // etc
    private void MImpl(object x)
    {
        // No more specific overloads matched. Throw some appropriate exception,
        // or take a default action.
    }
   

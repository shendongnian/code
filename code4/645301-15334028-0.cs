    static void Main()
    {
        try {Throw();}
        catch(Exception ex) {
            Console.Error.WriteLine(ex);
        }
    }
    public static void Throw()
    {
        throw new InvalidOperationException("oops");
    }

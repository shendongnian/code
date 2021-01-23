    // This allows us to point to a math function with this signature,
    // namely, takes two Int32 inputs, and returns an Int32.
    public static delegate Int32 MathDelegate(Int32 lhs, Int32 rhs);
    public static Int32 Add(Int32 lhs, Int32 rhs)
    {
        return lhs + rhs;
    }
    // Note the variable names aren't important, just their TYPE
    public static Int32 Subtract(Int32 a, Int32 b)
    {
        return a - b;
    }
    static void Main()
    {
        // We can use a delegate to point to a "real" function
        MathDelegate mathPerformer = Add;
        Console.WriteLine(mathPerformer(2, 3)); // Output : 5
        // Now let's point to "Subtract"
        mathPerformer = Subtract;
        Console.WriteLine(mathPerformer(2, 3)); // Output : -1
        Console.ReadLine();
    }

    private static dynamic Get() {
        return new {X=5};
    }
    public static void Main() {
        var v = Get();
        Console.WriteLine(v.X);
    }

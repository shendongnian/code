    public interface IFields
    {
        string Prop1 { get; set; }
        string Prop2 { get; set; }
    }
    public static void DoSmth<T>(List<T> items) where T : IFields
    {
        foreach (T t in items)
        {
            Console.WriteLine(t.Prop1);
            Console.WriteLine(t.Prop2);
        }
    }

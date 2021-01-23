    public interface IA { }
    public class A :IA { }
    object a = Activator.CreateInstance<A>();
    if (a is IA)
        Console.WriteLine("Yes");

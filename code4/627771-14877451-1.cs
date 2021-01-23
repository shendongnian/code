    public class A2 : A
    {
    }
    public static void DoSth(List<A> a)
    {
         a.Add(new A2()); // but a is a List<B>!!!
    }

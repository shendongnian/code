    public abstract class A { }
    public interface I { }
    public class C : A, I { }
    public class Program
    {
        static void Update<T>(List<T> l, A a, I i, C c)
            // HERE IS THE CHANGE
            where T: C
        {
            l.Add((T)a);//Error
            l.Add((T)i);
            l.Add((T)c);//Error
        }
    }

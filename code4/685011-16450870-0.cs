    void Main()
    {
        10.IsFoo(20).Dump();
        new Dummy().IsFoo(20).Dump();
    }
    
    public class Dummy : IComparable<int>
    {
        public int CompareTo(int other)
        {
            return 0;
        }
    }
    
    public static class Extensions
    {
        public static bool IsFoo<T>(this IComparable<T> value, T other)
            where T : IComparable<T>
        {
            Debug.WriteLine("1");
            return false;
        }
        
        public static bool IsFoo<T>(this T value, T other)
            where T : IComparable<T>
        {
            Debug.WriteLine("2");
            return false;
        }
    }

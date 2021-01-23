    public interface IA
    {
        int val { get; set; }
    }
    public interface IB<T> where T : IA
    {
        T a_val { get; set; }
    }
    public interface IC<T, U> where T : IB<U> where U : IA
    {
        T b_val { get; set; }
    }
    public class a : IA
    {
        public int val { get; set; }
    }
    public class b : IB<a>
    {
        public a a_val { get; set; }
    }
    public class c : IC<b, a>
    {
        public b b_val { get; set; }
    }

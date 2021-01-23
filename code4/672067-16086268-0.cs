    public interface IColor
    { }
    
    public struct BGR<T>: IColor
    {
        public T B;
        public T G;
        public T R;
    }
    
    public class Image<TColor> where TColor: IColor
    {
        TColor[,] data;
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Image<BGR<byte>> a;
        }
    }

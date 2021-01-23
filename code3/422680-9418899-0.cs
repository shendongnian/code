    class Program
    {
        static void Main(string[] args)
        {
            var oldEx = new ExClass[10, 10];
            var newEx = oldEx.init<ExClass>();
        }
    }
    public class ExClass
    {
        public string exString = "I AM NEW";
    }
    public static class tools
    {
        static public T[,] init<T>(this T[,] start)
        {
            var newArray = new T[start.GetLength(0), start.GetLength(1)];
            for (int y = 0; y < start.GetLength(0); y++)
            {
                for (int x = 0; x < start.GetLength(1); x++)
                {
                    newArray[y, x] = Activator.CreateInstance<T>();
                }
            }
            return newArray;
        }
    }

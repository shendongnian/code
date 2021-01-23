    class Program
    {
        static void Main(string[] args)
        {
            var oldEx = tools.init<ExClass>(10, 10);
        }
    }
    public class ExClass
    {
        public string exString = "I AM NEW";
    }
    public static class tools
    {
        static public T[,] init<T>(int x,int y)
        {
            var newArray = new T[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    newArray[i, j] = Activator.CreateInstance<T>();
                }
            }
            return newArray;
        }
    }

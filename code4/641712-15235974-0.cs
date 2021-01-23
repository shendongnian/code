    namespace ConsoleApplication2
    {
        public class Test
        {
            public int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            public void Insert(int index, int value)
            {
                for (int i = array.Length - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = value;
    
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
                t.Insert(5, 9);
                foreach (int i in t.array)
                {
                    Console.WriteLine(i);
                }
                Console.Read();
            }
        }
    }

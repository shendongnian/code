    public class Program
    {
        private readonly int[] ProgramArray = new int[10];
        public Program(int[] array)
        {
            ProgramArray = array;
            QuickSort();
            ReverseArray();
        }
        public void QuickSort()
        {
            var newarray = new int[10];
            newarray = (int[])ProgramArray.Clone();
            Array.Sort(newarray);
            Print(newarray, "QuickSort");
        }
        public void ReverseArray()
        {
            var newarray = new int[10];
            newarray = (int[])ProgramArray.Clone();
            Array.Reverse(newarray);
            Print(newarray, "Reversed");
        }
        public static void Print(int[] array, string methodname)
        {
            int[] newarray = array;
            Console.Write(string.Format("{0}: ", methodname));
            for (int i = 0; i < newarray.Length; i++)
            {
                Console.Write(newarray[i] + " ");
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            var array = new int[10] { 12, 24, 3, 44, 5, 16, 7, 34, 23, 34 };
            Print(array, "Original Array");
            var program = new Program(array);
            Console.ReadKey();
        }
    }

The foreach statement repeats a group of embedded statements for each element in an array or an object collection. The foreach statement is used to iterate through the collection to get the desired information, but should not be used to change the contents of the collection to avoid unpredictable side effects.
    class ForEachTest
    {
        static void Main(string[] args)
        {
            int[] fibarray = new int[] { 0, 1, 2, 3, 5, 8, 13 };
            foreach (int i in fibarray)
            {
                System.Console.WriteLine(i);
            }
        }

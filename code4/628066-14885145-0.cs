        static void Main()
        {
            int[] arr = new int[10];
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(0, numbers.Count - 1);
                arr[i] = numbers[index];
                numbers.RemoveAt(index);
            }
        }

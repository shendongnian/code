        public static void Main()
        {
            int[] numbers = new int[5] { 32, 67, 88, 13, 50 };
            
            StringBuilder valuesToBeHashed = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                valuesToBeHashed.Append(numbers[i] + ",");
            }
            Random rd = new Random(valuesToBeHashed.GetHashCode());
            Console.WriteLine("Hashcode of Array : {0} ",valuesToBeHashed.GetHashCode());
            Console.WriteLine("Random generated based on hashcode : {0}", rd.Next());
        }

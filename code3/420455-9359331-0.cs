            int input = 1000001;
            int[] columns_index = { 2, 3, 4 };
            int[] numbers = new int[input];
            // Times we can use everything in columns_index
            int times = input/columns_index.Length; // 333333
            List<int> numbersList = new List<int>();
            for (int i = 0; i < times; i++)
            {
                numbersList.AddRange(columns_index);
            }
            // numbersInt.Count is now 999999..
            // Times for the rest
            int modTimes = input%(columns_index.Length); // 2
            for (int j = 0; j < modTimes; j++)
            {
                numbersList.Add(columns_index[j]);
            }
            numbers = numbersList.ToArray();

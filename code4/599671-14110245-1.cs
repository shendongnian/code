      int[] GetPrimes(int number) // input should be greater than 1
        {
            bool[] arr = new bool[number + 1];
            var listPrimes = new List<int>();
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (!arr[i])
                {
                    int squareI = i * i;
                    for (int j = squareI; j <= number; j = j + i)
                    {
                        arr[j] = true;
                    }
                }
                for (int c = 1; c < number + 1; c++)
                {
                    if (arr[c] == false)
                    {
                        listPrimes.Add(c);
                    }
                }
            }
            return listPrimes.ToArray();
        }

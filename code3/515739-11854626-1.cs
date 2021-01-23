    var numbers = new int[] { 7,1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 2, 2, 1, 2, 1 };
    int maxCount = 0;
    for (int j = 0; j+1 < numbers.Length; j++)
    {
        int count = 0;
        if (numbers[j] < numbers[j+1])
        {
            count += 2;
            for (int i = j+2; i+1 < numbers.Length; i += 2)
            {
                if (numbers[i] < numbers[i + 1] )
                {
                    count += 2;
                }
                else
                {
                    break;
                }
            }
        }
        if (maxCount < count)
        {
            maxCount = count;
        }
    }
    Console.WriteLine(maxCount);
    Console.ReadLine();

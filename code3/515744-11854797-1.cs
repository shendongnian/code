    var numbers = new int[] { 1,2,1,2,1,2,1,2,1,2,1,2,1,2,2,2,1,2,1 };
    int count = 2, max = 0;
    for (int i = 1; i < numbers.Length - 1; i++)
    {
        
        if ((numbers[i - 1] < numbers[i] && numbers[i + 1] < numbers[i]) ||
                        (numbers[i - 1] > numbers[i] && numbers[i + 1] > numbers[i]))
        {
            count++;
            max = Math.Max(count, max);
        }
        else
        {
            count = 2;
        }
    }
    Console.WriteLine(max); // 14

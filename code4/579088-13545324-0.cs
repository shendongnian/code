        int intValue = 0;
        int[] numbers = new int[5];
        for (int i = 0; i < 4; i++)
        {
            input = Console.ReadLine();
            if (int.TryParse(input, out intValue))
                numbers[i] = intValue;
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            /*while (numbers[i] != 60)*/
            if (numbers[i] != 60)  // it should be if condition, while statement made it infinite
            {
                Console.WriteLine(intValue);
            }
        }

    for (int j = 1; j <= sum; j++)
    {
        if (sum % j == 0)
        {
            counter++;
            if (counter == 500)
            {
                isTrue = false;
                Console.WriteLine("Triangle number: {0}", sum);
                break;
            }
        }
    }

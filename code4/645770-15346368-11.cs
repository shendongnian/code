    for (int j = 1; j <= sum; j++)
    {
        if (sum % j == 0)
        {
            if(sum/j < j)
                break;
            else if(sum/j == j)
                counter++;
            else
                counter +=2;
            if (counter == 500)
            {
                isTrue = false;
                Console.WriteLine("Triangle number: {0}", sum);
                break;
            }
        }
    }

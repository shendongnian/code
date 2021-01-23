     bool isPrime = true;
                int number = Convert.ToInt32(Console.Read());
                int i = 2;
                while (i < number)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    i++;
                }
    
                if (isPrime)
                {
                    //Prime number
                }
                else
                {
                    //Not Prime No
                }

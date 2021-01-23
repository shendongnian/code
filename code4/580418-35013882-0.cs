            int num1, num2, mull = 1;
            
            num1 = int.Parse(Console.ReadLine());  
            num2 = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num1; i++)
            {
                for (int j = 1; j <= num2; j++)
                {
                    if (num1 * j == num2 * i)
                    {
                        mull = num2 * i;
                        Console.Write(mull); 
                        return;
                    }
                }
            }
            

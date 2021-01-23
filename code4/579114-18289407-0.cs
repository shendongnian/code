            Console.WriteLine("Enter a number");
            int i = int.Parse(Console.ReadLine());
            if (i < 20)
            {
                Console.WriteLine(ones[i]);
            }
            if (i > 30  & i < 100)
            {
                Console.WriteLine(tens[((i%100)/10)-1]+ " " + ones[(i % 10)]);
            }
            if (i > 100 & i < 1000)
            {
                if (((i % 100) % 10) == 0)
                {
                    Console.WriteLine(ones[(i / 100)] + " hundred " + tens[((i % 100) / 10) - 1]);
                }
                else
                {
                    Console.WriteLine(ones[(i / 100)] + " hundred " + tens[((i % 100) / 10) - 1] + " and " + ones[((i % 100) % 10)]);
                }
            }
            Console.ReadLine();

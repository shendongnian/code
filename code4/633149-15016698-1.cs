        double first, second, third, fourth;
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine("Enter a number : ");
            double input = Convert.ToDouble(Console.ReadLine());
            switch (i)
            {
                case 1:
                    first = input;
                    break;
                case 2:
                    second = input;
                    break;
                case 3:
                    third = input;
                    break;
                case 4:
                    fourth = input;
                    break;
            }
        }

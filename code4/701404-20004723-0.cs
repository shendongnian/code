            Console.Write("Enter how many numbers you want to enter and sum up: ");
  
            double n = double.Parse(Console.ReadLine());  
            double r;  
            double sum = 0;  
            for (int i = 0; i < n; i++)  
            {  
                Console.Write("{0} Enter number ", i);  
                r = double.Parse(Console.ReadLine());  
                sum += r;  
                Console.WriteLine(sum);  
            }  

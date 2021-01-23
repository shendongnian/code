            using System.Linq;
            
            .....
            Console.WriteLine("Hey there! If you could go ahead and just give me like 10 numbers, that'd be great... And I'll tell you what, if you do, I'll add them up and average them all up for ya.");
            // declare the array
            int[] aryNumbers = new int[10];
            for(int i =0; i<aryNumbers.Length;i++)
            {
                Console.WriteLine("Okay, give me a number.");
                aryNumbers[i] = int.Parse(Console.ReadLine());
            }
            int intAverage = (int)aryNumbers.Average();
            Console.WriteLine("You're average comes out to... " + intAverage);
            Console.ReadKey();           

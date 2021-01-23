    string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                                "eleven", "twelve", "thirtheen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen","nineteen", "twenty" };
    string[] tens = { "Ten", "Twenty", "Thirthy", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
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

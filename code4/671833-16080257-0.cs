        static void Main(string[] args)
        {
            Console.Write("Enter Number =");
            string n = Console.ReadLine();
            var sb = new StringBuilder();
            if (n.Length == 4)
            {
                if (int.Parse(n) <= 0)
                {
                    sb.Append("Zero");
                }
                else
                {
                    int[] digits = n.Select(i => Int32.Parse(i.ToString())).ToArray();
                    string[] unit = new string[]
                        {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
                    string[] tens = new string[]
                        {
                            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
                            "eighteen",
                            "nineteen"
                        };
                    string[] tens2 = new string[]
                        {"", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
                    if (digits[0] > 0)
                    {
                        sb.Append(unit[digits[0] - 1]);
                        sb.Append(" thousand, ");
                    }
                    if (digits[1] > 0)
                    {
                        sb.Append(unit[digits[1] - 1]);
                        sb.Append(" hundred and ");
                    }
                    if (digits[2] > 1)
                    {
                        sb.Append(tens2[digits[2] - 1]);
                        sb.Append(" ");
                        sb.Append(unit[digits[3] - 1]);
                    }
                    else if (digits[2] == 1)
                    {
                        sb.Append(tens[digits[3]]);
                    }
                    else
                    {
                        sb.Append(unit[digits[3] - 1]);
                    }
                }
                Console.WriteLine(sb.ToString());
            }
            else
            {
                Console.WriteLine("Only four digit number is supported in trial version of this program !!!");
            }
            
            Console.ReadKey();
        } 

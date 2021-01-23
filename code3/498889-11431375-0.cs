            int num1;
            int num2;
            string operand = string.Empty;
            float answer;
            string text1;
            
            ////enter first number ////
            Console.Write("Please enter a number: ");
            text1 = Console.ReadLine();
            // if number not integer then fail ////
            bool res = int.TryParse(text1, out num1);
            while (!res)
            {
                Console.WriteLine(" FAIL");
                ////enter first number ////
                Console.Write("Please enter a number: ");
                text1 = Console.ReadLine();
                res = int.TryParse(text1, out num1);
            }
            //// enter operand ////
            while (operand == string.Empty || operand.Length > 1 || !(new char[] { '+', '-', '*', '/' }).Contains(char.Parse(operand)))
            {
                Console.Write("Please enter an operand (+, -, /, *): ");
                operand = Console.ReadLine();
            }
            
            // enter second number //
            Console.Write("Please enter the second number: ");
            text1 = Console.ReadLine();
            // if number not integer then fail //
            bool eff = int.TryParse(text1, out num2);
            while (!eff)
            {
                Console.WriteLine(" FAIL");
                // enter second number //
                Console.Write("Please enter the second number: ");
                text1 = Console.ReadLine();
                eff = int.TryParse(text1, out num2);
            }
            // converts number to integer ///
            // makes operand answers from each number ////
            switch (operand)
            {
                case "-":
                    answer = num1 - num2;
                    break;
                case "+":
                    answer = num1 + num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Divide By Zero Error");
                        return;
                    }
                    answer = num1 / num2;
                    break;
                case "*":
                    answer = num1 * num2;
                    break;
                default:
                    answer = 0;
                    break;
            }
            /// converts numbers to string using operand and writes final line ///
            Console.WriteLine(num1.ToString() + " " + operand + " " + num2.ToString() + " =  "+ answer.ToString());
            Console.ReadLine();

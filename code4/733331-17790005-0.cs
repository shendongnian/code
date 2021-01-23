            String input = "------hello-----";
            int i = 1;
            while (i < input.Length)
            {
                if (input[i] == input[i - 1])
                {
                    input = input.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(input); // Will give "-helo-"

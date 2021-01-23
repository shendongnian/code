            string regularExpressionPattern = @"\{(.*?)\}";
            Regex re = new Regex(regularExpressionPattern);
            foreach (Match m in re.Matches(inputText))
            {
                Console.WriteLine(m.Value);
            }
            System.Console.ReadLine();

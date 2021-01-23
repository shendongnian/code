        private static void TrimRedundantSpaces(string input)
        {
            Console.WriteLine(input);
            StringBuilder output = new StringBuilder();
            char previousChar = '\0';
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '\'':
                        if (! inDoubleQuote)
                            inSingleQuote = !inSingleQuote;
                        output.Append(input[i]);
                        break;
                    case '"':
                        if (! inSingleQuote)
                            inDoubleQuote = !inDoubleQuote;
                        output.Append(input[i]);
                        break;
                    case ' ':
                        if ((previousChar != ' ') || inSingleQuote || inDoubleQuote)
                            output.Append(' ');
                        break;
                    default:
                        output.Append(input[i]);
                        break;
                }
                previousChar = input[i];
            }
            Console.WriteLine(output.ToString());
            Console.WriteLine();
        }
        [STAThread]
        static void Main(string[] args)
        {
            TrimRedundantSpaces("sqlcmd.exe    -Q 'LEAVE     SQL TEXT HERE   UNCHANGED BECAUSE IT'S IN A DBL QUOTE BLOCK'");
            TrimRedundantSpaces("sqlcmd.exe    -Q \"LEAVE     SQL TEXT HERE   UNCHANGED BECAUSE IT'S IN A DBL QUOTE BLOCK\"");
            TrimRedundantSpaces("sqlcmd.exe    -Q \"LEAVE     'SQL TEXT' HERE   UNCHANGED BECAUSE IT'S IN A DBL QUOTE BLOCK\"");
            Console.ReadLine();
        }

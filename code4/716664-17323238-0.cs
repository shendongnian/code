    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder code = new StringBuilder();
                compile("function Main {", code);
                compile("x = Hello world!!", code);
                compile("print x", code);
                compile("input x", code);
                compile("} ;", code);
                Console.WriteLine(code.ToString());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        static void compile(string line, StringBuilder code)
        {
            string[] tokens = line.Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Contains("function"))
                {
                    code.Append(":").Append(tokens[i+1]);
                    i++;
                }
                else if (tokens[i].Contains("="))
                {
                
                    code.Append("PUSH ").Append(tokens[i-1]).Append("\n");
                    code.Append("PUSH ").Append(tokens[i+1]).Append("\n");
                    code.Append("SET\n");
                    i++;
                }
                else if (tokens[i].Contains("exec"))
                {
                    code.Append("GOTO ").Append(tokens[i+1]).Append("\n");
                    i++;
                }
                else if (tokens[i].Contains("}"))
                {
                    code.Append("RTN\n");
                }
                else if (tokens[i].Contains("input"))
                {
                    code.Append("PUSH ").Append(tokens[i+1]).Append("\nPUSH NULL\nINPUT\n");
                }
                else if (tokens[i].Contains("print"))
                {
                    code.Append("PUSH ").Append(tokens[i+1]).Append("\nPUSH NULL\nPRINT\n");
                }
            }
        }
    }

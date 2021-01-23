    namespace Calculator
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Program calc = new Program();
                Program validate = new Program();
                bool valid = true;
    
                while (valid == true)
                {
                    Console.WriteLine("Supported functions are *, /, +, -, ^, %.");
                    Console.WriteLine("If you would like to find the greater number separate the numbers with a '?'");
                    String userInput = Console.ReadLine();
                    valid = validate.ValEntry(userInput);
    
                    Console.WriteLine(calc.Calculate(userInput));
                } /////////////////////////////////////////////////////////////////////////
            }
    
            private string Calculate(string input)
            {
                int opstringloc = findoperator(input);
                int firstval = int.Parse(input.Substring(0, opstringloc));
                int secondval = int.Parse(input.Substring(0, opstringloc));
                char operation = Convert.ToChar(input.Substring(opstringloc));
    
    
                switch (operation)
                {
                    case '+':
                        return Convert.ToString(firstval + secondval);
                        break;
                    case '-':
                        return Convert.ToString(firstval - secondval);
                        break;
                    case '/':
                        return Convert.ToString(firstval/secondval);
                        break;
                    case '*':
                        return Convert.ToString(firstval*secondval);
                        break;
                    case '%':
                        return Convert.ToString(firstval%secondval);
                        break;
                    case '^':
                        return Convert.ToString(firstval ^ secondval);
                        break;
                    case '?':
                        if (firstval < secondval)
                        {
                            return ("[0] < [1]");
                            Convert.ToString(firstval);
                            Convert.ToString(secondval);
                        }
                        else if (firstval > secondval)
                        {
                            return ("[0] > [1]");
                            Convert.ToString(firstval);
                            Convert.ToString(secondval);
                        }
                        else if (firstval == secondval)
                        {
                            return ("[0] = [1]");
                            Convert.ToString(firstval);
                            Convert.ToString(secondval);
                        }
                        break;
                    default:
                        return ("Invalid Entry, please try again.");
                        break;
                }
                return ("Invalid Entry, please try again.");
            }
    
            private bool ValEntry(string entry)
            {
                for (int p = 0; p < entry.Length; p++)
    
    
                    if (char.IsDigit(entry[p]))
                    {
                        return true;
                    }
                    else if ((entry[p] == '+') || (entry[p] == '-') || (entry[p] == '*') || (entry[p] == '/') ||
                             (entry[p] == '%') || (entry[p] == '^') || (entry[p] == '?'))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                return false;
            }
    
    
            private int findoperator(string oploc)
            {
    
                for (int loc = 0; loc < oploc.Length; loc++)
                {
                    if (!char.IsDigit(oploc[loc])) return loc;
                }
                return -1;
            }
    
    
        }
    }

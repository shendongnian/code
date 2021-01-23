    namespace FirstConsoleApplication
    {
    class Program
        {   
            static void Main(string[] args)
            {
    
                Console.WriteLine("Type in an integer vale");
                string num;
                num = Console.ReadLine();
                string result1 = function1(num);
                Console.WriteLine(result1);
                Console.ReadLine();
            }
    
            static string function1(string x)
            {
                Int32 isnumber = 0;
                bool canConvert = Int32.TryParse(x, out isnumber);
                string returnValue;
                if (canConvert == true)
                {
                    int val3 = Int32.Parse(x);
    
                    switch (val3)
                    {
                        case 50:
                            returnValue = "yep its 50";
                            break;
                        case 51:
                            returnValue = "hmmm.... its 51... what are you gonna do about that??";
                            break;
                        case 52:
                            returnValue = "lets not get sloppy now...";
                            break;
                        default:
                            returnValue = "nope, its definately something else";
                            break;
                    };
    
                }
                else
                {
                    returnValue = "Thats not a number";
                };
                return returnValue;
            }
        }
    }

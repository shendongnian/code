        static void Main(string[] args)
        {
            Console.WriteLine("Enter the desired Timespan");
            string s = Console.ReadLine();
            //ToDo: Make sure that s has the desired format
            //Get the TimeSpan, create a new list when the string does not contain a whitespace.
            TimeSpan span = s.Contains(' ') ? extractTimeSpan(new List<string>(s.Split(' '))) : extractTimeSpan(new List<string>{s});
            Console.WriteLine(span.ToString());
            Console.ReadLine();
        }
        static private TimeSpan extractTimeSpan(List<string> parts)
        {
            //We will add our extracted values to this timespan
            TimeSpan extracted = new TimeSpan();
            foreach (string s in parts)
            {
                if (s.Length > 0)
                {
                    //Extract the last character of the string
                    char last = s[s.Length - 1];
                    //extract the value
                    int value;
                    Int32.TryParse(s.Substring(0, s.Length - 1), out value);
                    switch (last)
                    {
                        case 'd':
                            extracted = extracted.Add(new TimeSpan(value,0,0,0));
                            break;
                        case 'h':
                            extracted = extracted.Add(new TimeSpan(value, 0, 0));
                            break;
                        case 'm':
                            extracted = extracted.Add(new TimeSpan(0, value, 0));
                            break;
                        case 's':
                            extracted = extracted.Add(new TimeSpan(0, 0, value));
                            break;
                        default:
                            throw new Exception("Wrong input format");
                    }
                }
                else
                {
                    throw new Exception("Wrong input format");
                }
            }
            return extr

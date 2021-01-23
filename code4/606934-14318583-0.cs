    using System;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(">{0}<", RemoveExtraSpaces("Hello, how are you?"));
                Console.WriteLine(">{0}<", RemoveExtraSpaces("Hello , how are  you?"));
                Console.WriteLine(">{0}<", RemoveExtraSpaces("Hello     ,     how    are   you    ?"));
            }
            public static string RemoveExtraSpaces(string text)
            {
                var buffer = new char[text.Length];
                bool isSpaced = false;
                int n = 0;
                foreach (char c in text)
                {
                    if (c == ' ')
                    {
                        isSpaced = true;
                    }
                    else
                    {
                        if (isSpaced)
                        {
                            if ((c != ',') && (c != '?'))
                            {
                                buffer[n++] = ' ';
                            }
                            isSpaced = false;
                        }
                        buffer[n++] = c;
                    }
                }
                return new string(buffer, 0, n);
            }
        }
    }

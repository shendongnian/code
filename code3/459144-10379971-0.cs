     static void Main(string[] args)
        {
            string theword = Console.ReadLine();
            char[] arrSplit = theword.ToCharArray();
            bool status = false;
            for (int i = 0; i < arrSplit.Length; i++)
            {
                if (i < theword.Length)
                {
                    string leftWord = theword.Substring(0, i);
                    char[] arrLeft = leftWord.ToCharArray();
                    Array.Reverse(arrLeft);
                    leftWord = new string(arrLeft);
                    string rightWord = theword.Substring(i + 1, theword.Length - (i + 1));
                    if (leftWord == rightWord)
                    {
                        status = true;
                        break;
                    }
                }
            }
            Console.Write(status);
            Console.ReadLine();
        }

        public static string Replace(this String str, char[] chars, string replacement)
        {
            StringBuilder output = new StringBuilder(str.Length);
            bool replace = false;
            if (chars.Length - 1 < 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    replace = false;
                    //  int val = Regex.Matches(ch.ToString(), @"[a-zA-Z]").Count;
                    for (int j = 0; j < chars.Length; j++)
                    {
                        if (chars[j] == c)
                        {
                            replace = true;
                            break;
                        }
                    }
                    if (replace)
                        output.Append(replacement);
                    else
                        output.Append(c);
                }
            }
            else
            {
                int j = 0;
                int truecount = 0;
                    char c1 = '\0';
                    for (int k = 0; k < str.Length; k++)
                    {
                       c1 = str[k];
                        if (chars[j] == c1)
                        {
                            replace = true;
                            truecount ++;
                        }
                        else
                        {
                            truecount = 0;
                            replace = false;
                            j = 0;
                        }
                        if(truecount>0)
                        {
                            j++;
                        }
                        if (j > chars.Length-1)
                        {
                            j = 0;
                        }
                        if (truecount == chars.Length)
                        {
                            output.Remove(output.Length - chars.Length+1, chars.Length-1);
                           // output.Remove(4, 2);
                            if (replace)
                                output.Append(replacement);
                            else
                                output.Append(c1);
                        }
                        else
                        {
                            output.Append(c1);
                        }
                    }
            }
            return output.ToString();
        }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a word");
        string word = (Console.ReadLine());
        Console.WriteLine("Enter a word to find");
        string find = (Console.ReadLine());
        Console.WriteLine("Enter a word to Replace");
        string Rep = (Console.ReadLine());
        Console.WriteLine(Replace(word, find.ToCharArray(), Rep));
        Console.ReadLine();
    }
}

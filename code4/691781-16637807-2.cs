        static void Main(string[] args)
        {
            string test = ".white> TD { color: white;box-shadow: 0px 0px 3px white, inset 0px 0px 5px black; white-space:pre-wrap; background-image='white black \" white \"'}";
            Console.WriteLine("Before: " + test);
            test = replaceInCSS(test, "white", "green");
            Console.WriteLine("After: " + test);
            Console.ReadLine();
        }
        static string replaceInCSS(string text, string replace, string replacement)
        {
            char[] forceBefore = new char[]{ '\n', '\t', ';', '{', ' '};
            char[] forceAfter = new char[] { ';', '}', ' ', ','};
            int index = text.IndexOf(replace, 0);
            while (index != -1)
            {
                if (!indexWithinString(text, index))
                {
                    int afterPos = index + replace.Length;
                    bool beforeOk = false, afterOk = false;
                    if (index > 0 && forceBefore.Contains<char>(text[index - 1]))
                        beforeOk = true;
                    if (afterPos < text.Length - 1 && forceAfter.Contains<char>(text[afterPos]))
                        afterOk = true;
                    if ((index == 0 || beforeOk) &&
                        (afterPos == text.Length - 1 || afterOk))
                    {
                        text = text.Remove(index, replace.Length);
                        text = text.Insert(index, replacement);
                    }
                }
                index = text.IndexOf(replace, index + 1);
            }
            return text;
        }
        static bool indexWithinString(string text, int index)
        {
            bool insideStrSimple = false;
            bool insideStrDouble = false;
            foreach (char c in text)
            {
                if (c == '\'' && !insideStrDouble)
                    insideStrSimple = !insideStrSimple;
                else if (c == '"' && !insideStrSimple)
                    insideStrDouble = !insideStrDouble;
            }
            return !insideStrDouble && !insideStrSimple;
        }

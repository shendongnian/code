    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Text.RegularExpressions;
    namespace StringReplaceTest
    {
        class Program
        {
            static string test1 = "A^@[BCD";
            static string test2 = "E]FGH\\";
            static string test3 = "ijk`l}m";
            static string test4 = "nopq~{r";
            static readonly Dictionary<char, string> repl =
                new Dictionary<char, string> 
                { 
                    {'^', "Č"}, {'@', "Ž"}, {'[', "Š"}, {']', "Ć"}, {'`', "ž"}, {'}', "ć"}, {'~', "č"}, {'{', "š"}, {'\\', "Đ"} 
                };
            static readonly Regex replaceRegex;
            static Program() // static initializer 
            {
                StringBuilder pattern = new StringBuilder().Append('[');
                foreach (var key in repl.Keys)
                    pattern.Append(Regex.Escape(key.ToString()));
                pattern.Append(']');
                replaceRegex = new Regex(pattern.ToString(), RegexOptions.Compiled);
            }
            public static string Sanitize(string input)
            {
                return replaceRegex.Replace(input, match =>
                {
                    return repl[match.Value[0]];
                });
            } 
            static string DoGeneralReplace(string input) 
            { 
                var sb = new StringBuilder(input);
                return sb.Replace('^', 'Č').Replace('@', 'Ž').Replace('[', 'Š').Replace(']', 'Ć').Replace('`', 'ž').Replace('}', 'ć').Replace('~', 'č').Replace('{', 'š').Replace('\\', 'Đ').ToString(); 
            }
            //Method for replacing chars with a mapping 
            static string Replace(string input, IDictionary<char, char> replacementMap)
            {
                return replacementMap.Keys
                    .Aggregate(input, (current, oldChar)
                        => current.Replace(oldChar, replacementMap[oldChar]));
            } 
            static void Main(string[] args)
            {
                for (int i = 1; i < 5; i++)
                    DoIt(i);
            }
            static void DoIt(int n)
            {
                Stopwatch sw = new Stopwatch();
                int idx = 0;
                Console.WriteLine("*** Pass " + n.ToString());
                // old way
                sw.Start();
                for (idx = 0; idx < 500000; idx++)
                {
                    string result1 = test1.Replace('^', 'Č').Replace('@', 'Ž').Replace('[', 'Š').Replace(']', 'Ć').Replace('`', 'ž').Replace('}', 'ć').Replace('~', 'č').Replace('{', 'š').Replace('\\', 'Đ');
                    string result2 = test2.Replace('^', 'Č').Replace('@', 'Ž').Replace('[', 'Š').Replace(']', 'Ć').Replace('`', 'ž').Replace('}', 'ć').Replace('~', 'č').Replace('{', 'š').Replace('\\', 'Đ');
                    string result3 = test3.Replace('^', 'Č').Replace('@', 'Ž').Replace('[', 'Š').Replace(']', 'Ć').Replace('`', 'ž').Replace('}', 'ć').Replace('~', 'č').Replace('{', 'š').Replace('\\', 'Đ');
                    string result4 = test4.Replace('^', 'Č').Replace('@', 'Ž').Replace('[', 'Š').Replace(']', 'Ć').Replace('`', 'ž').Replace('}', 'ć').Replace('~', 'č').Replace('{', 'š').Replace('\\', 'Đ');
                }
                sw.Stop();
                Console.WriteLine("Old (Chained String.Replace()) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms");
                Dictionary<char, char> replacements = new Dictionary<char, char>();
                replacements.Add('^', 'Č');
                replacements.Add('@', 'Ž');
                replacements.Add('[', 'Š');
                replacements.Add(']', 'Ć');
                replacements.Add('`', 'ž');
                replacements.Add('}', 'ć');
                replacements.Add('~', 'č');
                replacements.Add('{', 'š');
                replacements.Add('\\', 'Đ');
                // logicnp way
                sw.Reset();
                sw.Start();
                for (idx = 0; idx < 500000; idx++)
                {
                    char[] charArray1 = test1.ToCharArray();
                    for (int i = 0; i < charArray1.Length; i++)
                    {
                        char newChar;
                        if (replacements.TryGetValue(test1[i], out newChar))
                            charArray1[i] = newChar;
                    }
                    string result1 = new string(charArray1);
                    char[] charArray2 = test2.ToCharArray();
                    for (int i = 0; i < charArray2.Length; i++)
                    {
                        char newChar;
                        if (replacements.TryGetValue(test2[i], out newChar))
                            charArray2[i] = newChar;
                    }
                    string result2 = new string(charArray2);
                    char[] charArray3 = test3.ToCharArray();
                    for (int i = 0; i < charArray3.Length; i++)
                    {
                        char newChar;
                        if (replacements.TryGetValue(test3[i], out newChar))
                            charArray3[i] = newChar;
                    }
                    string result3 = new string(charArray3);
                    char[] charArray4 = test4.ToCharArray();
                    for (int i = 0; i < charArray4.Length; i++)
                    {
                        char newChar;
                        if (replacements.TryGetValue(test4[i], out newChar))
                            charArray4[i] = newChar;
                    }
                    string result4 = new string(charArray4);
                }
                sw.Stop();
                Console.WriteLine("logicnp (ToCharArray) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms");
                // oleksii way
                sw.Reset();
                sw.Start();
                for (idx = 0; idx < 500000; idx++)
                {
                    string result1 = DoGeneralReplace(test1);
                    string result2 = DoGeneralReplace(test2);
                    string result3 = DoGeneralReplace(test3);
                    string result4 = DoGeneralReplace(test4);
                }
                sw.Stop();
                Console.WriteLine("oleksii (StringBuilder) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms");
                // André Christoffer Andersen way
                sw.Reset();
                sw.Start();
                for (idx = 0; idx < 500000; idx++)
                {
                    string result1 = Replace(test1, replacements);
                    string result2 = Replace(test2, replacements);
                    string result3 = Replace(test3, replacements);
                    string result4 = Replace(test4, replacements);
                }
                sw.Stop();
                Console.WriteLine("André Christoffer Andersen (Lambda w/ Aggregate) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms");
                // Richard way
                sw.Reset();
                sw.Start();
                Regex reg = new Regex(@"\^@\[\]`\}~\{\\");
                MatchEvaluator eval = match =>
                {
                    switch (match.Value)
                    {
                        case "^": return "Č";
                        case "@": return "Ž";
                        case "[": return "Š";
                        case "]": return "Ć";
                        case "`": return "ž";
                        case "}": return "ć";
                        case "~": return "č";
                        case "{": return "š";
                        case "\\": return "Đ";
                        default: throw new Exception("Unexpected match!");
                    }
                };
                for (idx = 0; idx < 500000; idx++)
                {
                    string result1 = reg.Replace(test1, eval);
                    string result2 = reg.Replace(test2, eval);
                    string result3 = reg.Replace(test3, eval);
                    string result4 = reg.Replace(test4, eval);
                }
                sw.Stop();
                Console.WriteLine("Richard (Regex w/ MatchEvaluator) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms");
                // Marc Gravell way
                sw.Reset();
                sw.Start();
                for (idx = 0; idx < 500000; idx++)
                {
                    string result1 = Sanitize(test1);
                    string result2 = Sanitize(test2);
                    string result3 = Sanitize(test3);
                    string result4 = Sanitize(test4);
                }
                sw.Stop();
                Console.WriteLine("Marc Gravell (Static Regex) way completed in " + sw.ElapsedMilliseconds.ToString() + " ms\n");
            }
        }
    }

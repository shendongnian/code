    class Program
    {
        static List<string> _titles = new List<string> { "Mr", "Mrs", "Miss" };
        static List<string> _suffixes = new List<string> { "Jr", "Sr" };
        static void Main(string[] args)
        {
            var nameCombinations = new List<string>
            {
                "Mr and Mrs John and Mary Sue Smith Jr",
                "Mr and Mrs John and Mary Smith Jr",
                "Mr and Mrs John and Mary Sue Smith",
                "Mr and Mrs John and Mary Smith",
                "Mr and Mrs John Smith Jr",
                "Mr and Mrs John Smith",
                "John Smith",
                "Mr John Campbell Smith Jr",
                "Mr John Smith",
                "Mr John Smith Jr",
            };
            foreach (var name in nameCombinations)
            {
                Console.WriteLine(name);
                var breakdown = InterperetName(name);
                Console.WriteLine("    Title(s):       {0}", string.Join(", ", breakdown.Item1));
                Console.WriteLine("    First Name(s):  {0}", string.Join(", ", breakdown.Item2));
                Console.WriteLine("    Middle Name:    {0}", breakdown.Item3);
                Console.WriteLine("    Last Name:      {0}", breakdown.Item4);
                Console.WriteLine("    Suffix:         {0}", breakdown.Item5);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static Tuple<List<string>, List<string>, string, string, string> InterperetName(string name)
        {
            var segments = name.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<string> titles = new List<string>(),
                firstNames = new List<string>();
            string middleName = null, lastName = null, suffix = null;
            int segment = 0;
            for (int i = 0; i < segments.Length; i++)
            {
                var s = segments[i];
                switch (segment)
                {
                    case 0:
                        if (_titles.Contains(s))
                        {
                            titles.Add(s);
                            if (segments[i + 1].IsJoiner())
                            {
                                i++;
                                continue;
                            }
                            segment++;
                        }
                        else
                        {
                            segment++;
                            goto case 1;
                        }
                        break;
                    case 1:
                        firstNames.Add(s);
                        if (segments[i + 1].IsJoiner())
                        {
                            i++;
                            continue;
                        }
                        segment++;
                        break;
                    case 2:
                        if ((i + 1) == segments.Length)
                        {
                            segment++;
                            goto case 3;
                        }
                        else if ((i + 2) == segments.Length && _suffixes.Contains(segments[i + 1]))
                        {
                            segment++;
                            goto case 3;
                        }
                        middleName = s;
                        segment++;
                        break;
                    case 3:
                        lastName = s;
                        segment++;
                        break;
                    case 4:
                        if (_suffixes.Contains(s))
                        {
                            suffix = s;
                        }
                        segment++;
                        break;
                }
            }
            return new Tuple<List<string>, List<string>, string, string, string>(titles, firstNames, middleName, lastName, suffix);
        }
    }
    internal static class Extensions
    {
        internal static bool IsJoiner(this string s)
        {
            var val = s.ToLower().Trim();
            return val == "and" || val == "&";
        }
    }

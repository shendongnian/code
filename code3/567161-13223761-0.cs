    class Program
    {
        static List<T> removePatterns<T>(List<T> list)
        {
            List<T> cleaned = new List<T>();
            List<T> pattern = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                cleaned.Add(list[i]);
                pattern.Add(list[i]);
                // check if a pattern can be found ahead, increase pattern size slowly until something can be found
                int patternSize = -1;
                for (patternSize = 1; patternSize < pattern.Count + 1; patternSize++)
                {
                    List<T> currentPattern = pattern.Skip(pattern.Count - patternSize).ToList();
                    Boolean matches = true;
                    for (int o = 0; o < currentPattern.Count() && matches; o++)
                        matches = i + 1 + o < list.Count && list[i + 1 + o].Equals(currentPattern[o]);
                    if (matches)
                    {
                        pattern = new List<T>();
                        i += currentPattern.Count;
                        break;
                    }
                }
            }
            if (cleaned.Count != list.Count)
                return removePatterns(cleaned);
            return cleaned;
        }
        static void test(String list, String expected)
        {
            String result = String.Join("", removePatterns<String>(list.Select(c => c.ToString()).ToList()).ToArray());
            Console.WriteLine(list + " => " + result + " = " + expected);
            Console.WriteLine(result.Equals(expected) ? "Passed" : "Failed");
        }
        static void Main(string[] args)
        {
            test("ABBABBB", "AB");
            test("ABCDBCDA", "ABCDA");
            test("ABC", "ABC");
            test("ABBA", "ABA");
            test("ABCBCBCBC", "ABC");
            test("ABCDBC", "ABCDBC");
            Console.ReadKey();
        }
    }

    static class StringTrimExtension {
        public static string TrimStart(this string value, string toTrim) {
            if (value.StartsWith(toTrim)) {
                int startIndex = toTrim.Length;
                return value.Substring(startIndex);
            }
            return value;
        }
        public static string TrimEnd(this string value, string toTrim) {
            if (value.EndsWith(toTrim)) {
                int startIndex = toTrim.Length;
                return value.Substring(0, value.Length - startIndex);
            }
            return value;
        }
    }
    static void Main(string[] args) {
            string s = "Sammy";
            Console.WriteLine(s);
            string trimEnd = s.TrimEnd("my");
            string trimStart = s.TrimStart("Sa");
            Console.WriteLine(trimEnd);
            Console.WriteLine(trimStart);
            Console.ReadLine();
    }

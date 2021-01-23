        static void Main(string[] args)
        {
            const string outputPath = "output.txt";
            const string latin1GeneralCiAiKsWs = "Latin1_General_100_CI_AI_KS_WS";
            using (FileStream fileStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    CollationInfo latin_CI_AI = CollationInfo.GetCollationInfo(latin1GeneralCiAiKsWs);
                    string[] strings = { "aa", "AA", "äå", "ÄÅ" };
                    PrintHashCodes(latin1GeneralCiAiKsWs, s => latin_CI_AI.EqualityComparer.GetHashCode(s), streamWriter, strings); 
                    CompareInfo compareInfo = CultureInfo.GetCultureInfo(1033).CompareInfo;
                    MethodInfo GetHashCodeOfString = compareInfo.GetType().GetMethod("GetHashCodeOfString",
                        BindingFlags.Instance | BindingFlags.NonPublic,
                        null,
                        new[] { typeof(string), typeof(CompareOptions), typeof(bool), typeof(long) },
                        null);
                    Func<string, int> hackGetHashCode = s => (int)GetHashCodeOfString.Invoke(compareInfo,
                        new object[] { s, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace, false, 0L });
                    PrintHashCodes("----", hackGetHashCode, streamWriter, strings);
                }
            }
            Process.Start(outputPath);
        }
        private static void PrintHashCodes(string collation, Func<string, int> getHashCode, TextWriter writer, params string[] strings)
        {
            writer.WriteLine(Environment.NewLine + "Used collation: {0}", collation + Environment.NewLine);
            foreach (string s in strings)
            {
                WriteStringHashcode(writer, s, getHashCode(s));
            }
        }

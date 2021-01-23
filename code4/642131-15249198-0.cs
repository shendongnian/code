    private static void Main(string[] args)
            {
                Console.WriteLine(GetLetters(6));
                Console.ReadLine();
            }
    
            public static string GetLetters(int numberOfCharsToGenerate)
            {
                var random = new Random();
                char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
    
                var sb = new StringBuilder();
                for (int i = 0; i < numberOfCharsToGenerate; i++)
                {
                    int num = random.Next(0, chars.Length);
                    sb.Append(chars[num]);
                }
                return sb.ToString();
            }

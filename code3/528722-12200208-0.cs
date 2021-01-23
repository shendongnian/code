        static void Main(string[] args)
        {
            Console.WriteLine(GetLastParts(@"D:\Temp\X\Y\2012\08\27\18\36\tx84uwvr.puq", @"\", 6));
            Console.ReadLine();
        }
        static string GetLastParts(string text, string separator, int count)
        {
            string[] parts = text.Split(new string[] { separator }, StringSplitOptions.None);
            return string.Join(separator, parts.Skip(parts.Count() - count).Take(count).ToArray());
        }

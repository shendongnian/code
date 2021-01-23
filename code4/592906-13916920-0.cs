    static class StringExt
    {
        public static string InsertAfterEvery(
            this string source, string insert, int every, string find)
        {
            int numberFound = 0;
            int index = 0;
            while (index < source.Length && index > -1)
            {
                index = source.IndexOf(find, index) + find.Length;
                numberFound++;
                if (numberFound % every == 0)
                {
                    source = source.Insert(index, insert);
                    index += insert.Length;
                }
            }
            return source;
        }
    }
    // I used 3 rather than 15
    Console.WriteLine(
        "db 4Dh, 5Ah, 80h, 00h, 01h, 00h, 00h, 00h, 04h,".InsertAfterEvery(
            Environment.NewLine, 3, ","));

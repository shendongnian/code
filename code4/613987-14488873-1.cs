    private static List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };
    public static string Foo(int number)
    {
        for (int i = 0; i < suffixes.Count; i++)
        {
            int temp = number / (int)Math.Pow(1024, i + 1);
            if (temp == 0)
                return (number / (int)Math.Pow(1024, i)) + suffixes[i];
        }
        return number.ToString();
    }

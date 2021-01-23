    private static List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };
    public static string Foo(int number)
    {
        for (int i = 0; i < suffixes.Count; i++)
        {
            int temp = number / (1024 * i);
            if (temp / 1024 == 0)
                return (number / (1024 * (i - 1))) + suffixes[i];
        }
        return number.ToString(); //or whatever else to do if it's too big
    }

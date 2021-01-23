    private void GenerateStringsRecursive(List<string> strings, int n, string cur)
    {
        if (cur.Length == n)
        {
            strings.Add(cur);
        }
        else
        {
            GenerateStringsRecursive(strings, n, cur + "0");
            GenerateStringsRecursive(strings, n, cur + "1");
        }
    }

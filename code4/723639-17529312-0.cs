    void Main()
    {
        string input = "aabbbbchhhhaaaacc";
        var dic = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (dic.ContainsKey(c))
            {
                dic[c]++;
            }
            else
            {
                dic[c] = 1;
            }
        }
        foreach (var item in dic)
        {
            Console.WriteLine("{0}: {1}", item.Key, new string(item.Key, item.Value));
        }
    }

    static void Show()
    {
        IEnumerable<string> lst = new string[]{"001001009001", "001001009002", 
           "001001009003", "001001009004", "001001009005", "001001010002", 
           "001001010003" };
        var res = Process(lst);
        forech(string str in res)
        {
            Console.WriteLine(str);
        }
    }
    static List<string> Process(IEnumerable<string> input)
    {
        Dictionary<string, int[]> elements = new Dictionary<string,int[]>();
        foreach (var str in input)
        {
            string element = str.Substring(0, 9);
            int privelegeNumber = int.Parse(str.Substring(9, 3));
            if (!elements.ContainsKey(element))
            {
                elements.Add(element, Enumerable.Repeat(0, 5).ToArray());
            }
            elements[element][privelegeNumber - 1] = 1;
        }
        List<string> result = new List<string>();
        foreach (var element in elements)
        {
            StringBuilder sb = new StringBuilder(21);
            sb.Append(element.Key.Substring(0, 3));
            sb.Append(",");
            sb.Append(element.Key.Substring(3, 3));
            sb.Append(",");
            sb.Append(element.Key.Substring(6, 3));
            foreach (int privelege in element.Value)
            {
                sb.Append(",");
                sb.Append(privelege);
            }
            result.Add(sb.ToString());
        }
        return result;
    }

    var input = "D93:E93 E98 E9:E10 E26 D76:E76 D83:E83 D121:D124";
    var list = input.Split(' ');
    var result = new List<String>();
    foreach (var item in list)
    {
        var parts = item.Split(':');
        if (parts.Length == 1) result.Add(parts[0]);
        else
        {
            if (parts[0].Substring(0, 1).CompareTo(parts[1].Substring(0, 1)) == 0)
            {
                var i = Convert.ToInt32(parts[0].Substring(1));
                var j = Convert.ToInt32(parts[1].Substring(1));
                while (i < j)
                {
                    result.Add(parts[0].Substring(0, 1) + i);
                    i++;
                }
                if (i == j)
                {
                    result.Add(parts[0].Substring(0, 1) + i);
                }
            }
            else
            {
                result.Add(parts[0]);
                result.Add(parts[1]);
            }
        }
    }
    Console.WriteLine(string.Join(", ", result));
    //output
    D93, E93, E98, E9, E10, E26, D76, E76, D83, E83, D121, D122, D123, D124

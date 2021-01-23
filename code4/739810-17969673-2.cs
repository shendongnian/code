    string[] ary = new string[3] {"Name", "Groups[0].Id", "Types[11].Name" };
         
    ary = ary.Where(a => Regex.Match(a, @"\[[^\]]+\]\.").Success).ToArray();
    foreach (string str in ary)
    {
         Console.WriteLine(str);
    }

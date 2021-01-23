    List<string> mylist = new List<string>() { field_0_0.Value, field_0_1.Value };
        List<string> newlist = new List<string>(mylist.Count);
        foreach (string item in mylist)
        {
            newlist.Add(item.Replace(" ", ""));
        }
        string[] thelist = new string[2];
        string[] thenewlist = new string[thelist.Length];
        thelist[0] = "jeroen";
        thelist[1] = "joost";
        for (int i = 0; i < thelist.Length; i++)
        {
            thenewlist[i] = thelist[i].Replace(" ", "");
        }

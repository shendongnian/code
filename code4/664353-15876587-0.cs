    String str = "xyz,abc,lmnk";
    String[] Splitted = str.Split(',');
    foreach (var word in Splitted)
    {
        if (!String.IsNullOrEmpty(word))
            listView1.Items.Add(word);
    }

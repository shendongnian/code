    Dictionary<String, Country> dict = new Dictionary<string, Country>();
    dict.Add("Toronto", Country.Canada);
    dict.Add("New York", Country.US);
    dict.Add("Vancover", Country.Canada);
    dict.Add("Seattle", Country.US);
    dict.Add("Fredericton", Country.Canada);
    Lookup<Country,String> lookup = (Lookup<Country,String>) dict.ToLookup(pair =>pair.Value, pair => pair.Key);
     foreach (var countryGroup in lookup)
     {
        item = new ListViewItem(countryGroup.Key.ToString());
        item.SubItems.Add(string.Format("{0}", string.Join(",", countryGroup.Select(s => "@" + s))));
        lv.Items.Add(item);
        item = null;
     }

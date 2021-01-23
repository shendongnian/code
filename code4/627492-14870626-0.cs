    List<string> substring_list = new List<string>();
    foreach (string item in list)
    {
        int first = item.IndexOf("#");
        int second = item.IndexOf("#", first);
        substring_list.Add(item.Substring(first, second - first);
    }

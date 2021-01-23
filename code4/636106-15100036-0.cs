    Dictionary<int, string> dict = new Dictionary<int, string>();
    List<int> temp = new List<int>();
    dict.Add(123, "");
    dict.Add(124, ""); //and so on
    foreach (int key in dict.Keys.ToList())
    {
                if (dict[key] == "")
                {
                    temp.Add(key);
                    dict[key] = "Moved";
                }
            }
    }

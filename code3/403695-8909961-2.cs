    List<string> temp = new List<string>();
    foreach(string s in spaceSplit)
      if (s.Length>23)
        temp.AddRange(s.Replace("T", " T").Replace("S", " S").Split(' '));
      else
        temp.Add(s);

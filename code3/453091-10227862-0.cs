    List<string> fileLines = File.ReadAllLines(fileName).Skip(4).ToList();
          foreach (var item in fileLines)
          {
            values = item.Split(' ');
            string[] vl=values[3].Substring(2).Trim().Split('\t');
            sList1.Add(vl[0]);
            sList2.Add(vl[1]);
          }

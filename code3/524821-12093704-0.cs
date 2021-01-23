    string fr = "banana,banana,cherry,kiwi,strawberry";
        IList<string> selFr = fr.Split(new string[] { "," }, StringSplitOptions.None);
        IList<string> look = new List<string>();
        // Add the lookup values to the "look" list here...
        IList<string> res = new List<string>();
        foreach (string lookupStr in look) {
            foreach (string f in selFr) {
                if (lookupStr.Contains(f)) {
                      res.Add(lookupStr);
                      continue;
                }
            }
         }
      return res;

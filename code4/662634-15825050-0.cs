    public class Pair
    {
      public string First;
      public string Second;
    }
    
    
    List<Pair> pairs = new List<Pair>();
    for (int index = 0; iter < str.Length; index++)
    {
        var pair = str[index].Split(',');
        pairs.Add(new Pair(){First = pair[0], Second = pair[1]});
    }
    List<Pair> ordered = new List<Pair>();
    ordered.Add(pairs[0]);
    pairs.RemoveAt(0);
    while (pairs.Count > 0)
    {
        bool found = false;
        for (int iter = 0; iter < pairs.Count; iter++)
        {
            if (ordered[ordered.Count - 1].Second == pairs[iter].First)
            {
                ordered.Add(pairs[iter]);
                pairs.RemoveAt(iter);
                found = true;
                break;
            }
        }
        if (!found)
        {
          <report error>
          break;
        }
    }

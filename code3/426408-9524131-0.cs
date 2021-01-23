    List<int> endResult = new List<int>();
    StringBuilder tempSb = new StringBuilder();
    for(int i=0; i < groups.Count; i++)
    {
        if(i % 4 == 0) {
            endResult.Add(int.Parse(sb.ToString()));
            tempSb.Clear(); // remove what was already added
        }
        tempSb.Append(group[i]);
    }
    // check to make sure there aren't any stragglers left in
    // the StringBuilder. Would happen if the count of groups is not a multiple of 4
    if(groups.Count % 4 != 0) {
        groups.Add(int.Parse(sb.ToString()));
    }

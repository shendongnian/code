    string ReplaceMatch(Match m)
    {
        for (int i = 0; i < m.Groups.Count; i++)
        {
            string groupName = _regex.GroupNameFromNumber(i);
            switch (groupName)
            {
                case "BytesCompleted":
                    // do something
                    break;
                case "BytesRemaining":
                    // do somehting else
                    break;
                ...
            }
        }
        ...
    }
 

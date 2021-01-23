    public void AddTagtoGroup(string groupName, Tag tag)
    {
        Group group = FindGroupByName(groupName);
        if (group != null) {
            group.Add(tag);
        }
    }
 

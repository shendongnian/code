    void CreateGroup(string groupName)
    {
         listBox2.Items.Add(groupName);
         if (!listOfGroups.ContainsKey(groupName)
                    listOfGroups.Add(groupName, new List<string>());
    }

    public void Save(Application incomingApp)
    {
        if (incomingApp == null) { throw new ArgumentNullException("incomingApp"); }
        int[] groupIds = GetGroupIds(incomingApp);
        Application appToSave;
        if (incomingApp.IdForEf == 0)  // New app
        {
            appToSave = incomingApp;
            // Clear groups, otherwise new groups will be added to the groups table.
            appToSave.CustomVariableGroups.Clear();
            this.Database.Applications.Add(appToSave);                
        }
        else
        {
            appToSave = this.Database.Applications.Single(x => x.IdForEf == incomingApp.IdForEf);
        }
        AddGroupsToApp(groupIds, appToSave);
        this.Database.SaveChanges();
    }
    private void AddGroupsToApp(int[] groupIds, Application app)
    {
        List<CustomVariableGroup> groupsFromDb2 =
            this.Database.CustomVariableGroups.Where(g => groupIds.Contains(g.IdForEf)).ToList();
        foreach (CustomVariableGroup group in groupsFromDb2)
        {
            app.CustomVariableGroups.Add(group);
        }
    }
    private static int[] GetGroupIds(Application application)
    {
        int[] groupIds = new int[application.CustomVariableGroups.Count];
        int i = 0;
        foreach (CustomVariableGroup group in application.CustomVariableGroups)
        {
            groupIds[i] = group.IdForEf;
            i++;
        }
        return groupIds;
    }

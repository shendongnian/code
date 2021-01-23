    public IEnumerable<ApplicationServer> GetAll()
    {
        return this.Database.ApplicationServers
            .Include(x => x.ApplicationsWithOverrideGroup.Application)
            .Include(x => x.ApplicationsWithOverrideGroup.CustomVariableGroup)
            .Include(x => x.ApplicationWithGroupToForceInstallList)
            .Include(x => x.CustomVariableGroups)
            .ToList();
    }

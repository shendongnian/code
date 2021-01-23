    public IEnumerable<ApplicationServer> GetAll()
    {
        return this.Database.ApplicationServers
            .Include(x => x.ApplicationsWithOverrideGroup.Select(y => y.Application))
            .Include(x => x.ApplicationsWithOverrideGroup.Select(y => y.CustomVariableGroup))
            .Include(x => x.ApplicationWithGroupToForceInstallList)
            .Include(x => x.CustomVariableGroups)
            .ToList();
    }

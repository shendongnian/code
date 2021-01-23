    private List<Identity> ListGroupsSelectionChanged()
    {
        const string projectName = "<<TFS PROJECT NAME>>";
        const string groupName = "Contributors";
        const string projectUri = "<<TFS PROJECT COLLECTION>>";
    
        TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(projectUri));
        ICommonStructureService css = (ICommonStructureService) projectCollection.GetService(typeof(ICommonStructureService));
        IGroupSecurityService gss = projectCollection.GetService<IGroupSecurityService>();
    
        // get the tfs project
        var projectList = css.ListAllProjects();
        var project = projectList.FirstOrDefault(o => o.Name.Contains(projectName));
    
        // project doesn't exist
        if (project == null) return null;
    
        // get the tfs group
        var groupList = gss.ListApplicationGroups(project.Uri);
        var group = groupList.FirstOrDefault(o => o.AccountName.Contains(groupName));  // you can also use DisplayName
    
        // group doesn't exist
        if (group == null) return null;
    
        Identity sids = gss.ReadIdentity(SearchFactor.Sid, group.Sid, QueryMembership.Expanded);
            
        // there are no users
        if (sids.Members.Length == 0) return null;
    
        // convert to a list
        List<Identity> contributors = gss.ReadIdentities(SearchFactor.Sid, sids.Members, QueryMembership.None).ToList();
    
        return contributors;
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.TeamFoundation.Server;
    using Microsoft.TeamFoundation.Client;
    private List<Identity> ListGroupsSelectionChanged()
    {
    	TfsTeamProjectCollection projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("<<TFS PROJECT COLLECTION>>"));
    	ICommonStructureService iss = (ICommonStructureService) projectCollection.GetService(typeof(ICommonStructureService));
    	IGroupSecurityService gss = projectCollection.GetService<IGroupSecurityService>();
    	Identity sids = gss.ReadIdentity(SearchFactor.AccountName, "Project Collection Valid Users", QueryMembership.Expanded);
    
    	// there are no valid users
    	if (sids.Members.Length == 0)
    	{
    		return null;
    	}
    
    	// convert to a list
    	List<Identity> validUsers = gss.ReadIdentities(SearchFactor.Sid, sids.Members, QueryMembership.None).ToList();
    
    	return validUsers;
    }

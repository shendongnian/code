    return uow.Profiles.FindByID(profileId).Select
    	(p => Json(
    		new Organisation()
    		{
    			Name = p.Competitor.Name,
    			ID = p.Competitor.ID,
    			IsClient = p.Competitor.IsClient,
    			IsDeleted = p.Competitor.IsDeleted
    		},
    		JsonRequestBehavior.AllowGet)
    	);

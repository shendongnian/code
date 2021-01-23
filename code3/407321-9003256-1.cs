    var profilelst
      = dbContext.ProspectProfiles
                 .Where(i => i.CreateId == currentUser)
                 .Select(i => 
                        {
                            var opportunity
                               = i.Opportunities
                                  .OrderByDescending(t => t.FollowUpDate)
                                  .First();
                            return new ProspectProfile
                            {
                                ProspectId = i.ProspectId,
                                Live = i.Live, 
                                Name = i.Name,
                                ServiceETA = opportunity.ServiceETA.ToString(),
                                FollowUpDate = opportunity.FollowUpDate
                            }
                        }).ToList();
    return profilelst.OrderByDescending(c => c.FollowUpDate).Take(endIndex).ToList();

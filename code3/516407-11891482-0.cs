      public List<LeadRestrictionsDto> GetLeadRestrictionListingNow(Guid id)
      {
          var restrictions = from user in Manager.Users
                             join lead in Manager.Leads on user.UserId equals lead.OriginalOwnerId
                             join restriction in Manager.UserRestrictionListings on user.UserId equals restriction.UserId
                             where user.UserId == id && (restriction.RestrictionId == 100 || restriction.RestrictionId == 200) && restriction.Active == true
                             select new 
                                        {
                                            Modified = restriction.Modified,
                                            RestrictionDescription = restriction.Description,
                                            UserId = user.UserId,
                                            LeadId = lead.LeadId,
                                            FirstName = lead.FirstName,
                                            Created = lead.Created,
                                            LastName = lead.LastName
                                   
                                        };
          return restrictions.ToList().Select(x=>new LeadRestrictionsDto()
                                            {
                                                Modified = x.Modified,
                                                RestrictionDescription =  x.RestrictionDescription,
                                                UserId = x.UserId,
                                                LeadId = x.LeadId,
                                                FirstName = x.FirstName,
                                                Created = x.Created,
                                                LastName = x.LastName
                                            }).ToList();
      }

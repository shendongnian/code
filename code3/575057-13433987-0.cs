    var actList = (from a in db.Activities
                               join la in db.ListingActivities on a.ActivityId equals la.Activity.ActivityId into
                                   tempActivities
                               from listingActivites in tempActivities.DefaultIfEmpty()
                               select new ListingActivityItem()
                                          {
                                              ListingActivityId = listingActivites.ListingActivityId,
                                              Activity = a,
                                              Checked = listingActivites.Listing != null
                                          }).OrderBy(p=>p.Activity.Name).ToList();
                return actList;

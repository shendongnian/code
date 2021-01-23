            using (BusinessModelContainer bm = new BusinessModelContainer())
            {
                List<BusinessUnit> allBusinessUnits = bm.BusinessUnits.ToList();
                var userWithPermissions = (from u in bm.Users.Include("UserPermissions")
                                           where u.UserID == 1234
                                           select u).Single();
                List<BusinessUnit> unitsForUser = new List<BusinessUnit>();
                var explicitlyPermittedUnits = from p in userWithPermissions.UserPermissions
                                               select p.BusinessUnit;
                foreach (var bu in explicitlyPermittedUnits)
                {
                    unitsForUser.Add(bu);
                    unitsForUser.AddRange(GetChildren(bm, bu));
                }
                var distinctUnitsForUser = (from bu in unitsForUser
                                            group bu by bu.BusinessUnitID into q
                                            select q.First()).ToList();
            }

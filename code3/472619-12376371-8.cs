        private static IEnumerable<BusinessUnit> UnitsForUser(BusinessModelContainer container, User user)
        {
            var distinctTopLevelBusinessUnits = (from u in container.BusinessUnits
                                                 where u.UserPermissions.Any(p => p.UserID == user.UserID)
                                                 select u).Distinct().ToList();
            List<BusinessUnit> allBusinessUnits = new List<BusinessUnit>();
            foreach (BusinessUnit bu in distinctTopLevelBusinessUnits)
            {
                allBusinessUnits.Add(bu);
                allBusinessUnits.AddRange(GetChildren(container, bu));
            }
            return (from bu in allBusinessUnits
                    group bu by bu.BusinessUnitID into d
                    select d.First()).ToList();
        }
        private static IEnumerable<BusinessUnit> GetChildren(BusinessModelContainer container, BusinessUnit unit)
        {
            var eligibleChildren = (from u in unit.ChlidBusinessUnits
                                    select u).Distinct().ToList();
            foreach (BusinessUnit child in eligibleChildren)
            {
                yield return child;
                foreach (BusinessUnit grandchild in child.ChlidBusinessUnits)
                {
                    yield return grandchild;
                }
            }
        }

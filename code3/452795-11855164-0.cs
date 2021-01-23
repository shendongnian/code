    Part part =  null;
    Car car = null;
    var qoParts = QueryOver.Of<Part>(() => part)
                    .WhereRestrictionOn(x => x.PartId).IsIn(partIds)
                    .JoinQueryOver(x => x.Cars, () => car)
                    .Where(Restrictions.Eq(Projections.Count(() => car.CarId), partIds.Length))
                    .Select(Projections.Group(() => car.CarId));

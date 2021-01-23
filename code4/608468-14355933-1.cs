    var results = SomeRepository.HybridQuery(someDataQuery)
                                .Where(x => x.SomeColumn == 1 || x.SomeColumn == 2)
                                .OrderByDescending(x => x.SomeOtherColumn)
                                .AsEnumerable()
                                .Select(x => someDataMapper.Map(x));

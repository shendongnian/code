    Func<int, string> ageGroup = age => string.Format("Age {0}-{1}", (age / 5) * 5, ((age / 5) * 5) + 4);
    var blub = from row in table.AsEnumerable()
               where row.IsActive == 1
               group row by ageGroup(row.age)
               into grouped
               from g in grouped
               let menCount = g.Aggregate(0, (sum, r) => sum + r.men)
               let womenCount = g.Aggregate(0, (sum, r) => sum + r.women)
               let totalCount = menCount + womenCount
               select new { AgeGroup = g.Key, Men = menCount, Women = womenCount, Total = totalCount}

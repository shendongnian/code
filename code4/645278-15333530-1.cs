    table1.AsEnumerable().Concat(table2.AsEnumerable())
          .GroupBy(r => r.Field<string>("Name"))
          .Select(g => new {
              Name = g.Key,
              Ranks = g.Select(x => x.Field<int>("Rank")).ToList()
          })
          .Select(x => new {
              x.Name,
              Rank1 = x.Ranks.Count(r => r == 1),
              Rank2 = x.Ranks.Count(r => r == 2),
              Rank3 = x.Ranks.Count(r => r == 3),
              OtherRank = x.Ranks.Count(r => r > 3)
          }).CopyToDataTable();

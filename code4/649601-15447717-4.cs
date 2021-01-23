    var model = from x in lst
                group x by x.Value into g
                select new FooViewModel {
                   Value = g.Key,
                   Aliases = String.Join(", ", g.Select(i => i.Alias))
                };

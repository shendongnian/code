    ProductHistorical.Where(p => p.Id == 1)
            .Select(
                p => new
                {
                    DateChange = p.Date,
                    Col1 = p.Col1,
                    Col2 = p.Col2,
                    Col3 = p.Col3
                })
            .OrderBy(p => p.DateChange)
            .WhereWithPrevious((prev, curr) =>
                   prev.Col1 != curr.Col1
                || prev.Col2 != curr.Col2
                || prev.Col3 != curr.Col3)

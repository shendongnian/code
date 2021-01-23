    var result = table.Select(x =>
        new
        {
            Date = x.Date,
            PrevDate = table.Where(y => y.Date < x.Date)
                            .Select(y => y.Date)
                            .Max()
        });

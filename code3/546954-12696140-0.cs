    sOrderBy.Split(',')
            .Select(csv=> csv.Trim().Split(' '))
            .Select(splitBySpaces => new OrderByColumn()
                         {
                             ColumnName = splitBySpaces[0].Trim(),
                             IsAscending = (splitBySpaces[1].Trim() == "ASC")
                         })
            .ToList<OrderByColumn>()

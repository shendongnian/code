    sOrderBy.Split(',').Select(x => 
        {
            var trimmedSplitted = x.Trim().Split(' ');
            return new OrderByColumn()
            {
                ColumnName = trimmedSplitted[0].Trim(),
                IsAscending = (trimmedSplitted[1].Trim() == "ASC")
            }
        }
    ).ToList<OrderByColumn>()

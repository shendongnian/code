    dnFolders = 
        from row in dnDataTable.AsEnumerable()
        group row by new
        {
            id = row.Field<string>(1),
            value = row.Field<string>(2)
        } into g
        select new folder
        {
            id = g.Key.id,
            value = g.Key.value
            folderItems = g.Select(r => new folderItem { type = r.Field<string>(3) })
                           .ToList()
        };

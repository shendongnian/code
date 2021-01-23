    dnFolders = 
        (from row in dnDataTable.AsEnumerable()
        group row by new
        {
            id = row.Field<string>(1),
            value = row.Field<string>(2)
        } into g
        select new folder
        {
            id = g.Key.id,
            value = g.Key.value
            folderItems = g.Select(r => r.Field<FolderItems>(5) })
                           .ToList()
        }).ToList();

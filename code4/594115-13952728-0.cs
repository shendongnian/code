    int? index = new System.Data.DataView(dt).ToTable(false, new[] { "1" })
                    .AsEnumerable()
                    .Select(row => row.Field<string>("1")) // ie. project the col(s) needed
                    .ToList()
                    .FindIndex(col => col == "G");

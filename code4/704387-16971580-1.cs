    List<TableInfo> tables = 
        dtImportedTables.Tables.Zip(Globals.tblSchemaTable.Rows.AsEnumerable(),
            (table, schemaRow) => new TableInfo {
                Name = schemaRow[2].ToString(),
                // Again, only if you really need it
                ColumnCount = table.Columns.Count,
                Columns = table.Columns.Select(column => new ColumnInfo {
                            Name = column.ColumnName,
                            Type = column.DataType.Name
                          }).ToList()
            }
        }).ToList();

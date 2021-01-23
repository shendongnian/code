    public static string ToXml(this DataTable table, int metaIndex = 0)
    {
        XDocument xdoc = new XDocument(
            new XElement(table.TableName,
                from column in table.Columns.Cast<DataColumn>()
                where column != table.Columns[metaIndex]
                select new XElement(column.ColumnName,
                    from row in table.AsEnumerable()
                    select new XElement(row.Field<string>(metaIndex), row[column])
                    )
                )
            );
    
        return xdoc.ToString();
    }

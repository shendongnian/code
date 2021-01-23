    public static class Extensions
    {
        public static XElement ToXml(this DataTable table, string rowElementName)
        {
            // check if table has name and rowElementName is not empty           
    
            return new XElement(
                new XElement(table.TableName,
                    from row in table.AsEnumerable()
                    select new XElement(rowElementName,
                        from column in table.Columns.Cast<DataColumn>()
                        let value = row.Field<string>(column)
                        where value != null
                        select new XAttribute(column.Caption, value)
                        )
                    )
                );
        }
    }

    public static class Extensions
    {
        public static XDocument ToXml(this DataTable table)
        {
            if (String.IsNullOrEmpty(table.TableName))
               throw new ArgumentException("Table name is required");
            var pluralizationService = PluralizationService
                    .CreateService(new CultureInfo("en-US"));
            string elementName = pluralizationService.Singularize(table.TableName);
            return new XDocument(
                new XElement(table.TableName,
                    from row in table.AsEnumerable()
                    select new XElement(elementName,
                        from column in table.Columns.Cast<DataColumn>()
                        let value = row.Field<string>(column)
                        where value != null
                        select new XAttribute(column.Caption, value)
                        )
                    )
                );
        }
    }

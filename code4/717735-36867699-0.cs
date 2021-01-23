    public sealed class PersonMap : CsvClassMap<Person> {
        public override void CreateMap() {
            Map(m => m.FirstName).Name("FirstName").Index(0);
            Map(m => m.LastName).Name("LastName").Index(1);
            Map(m => m.Attributes).ConvertUsing(row =>
                (row as CsvReader)?.FieldHeaders
                     .Where(header => header.StartsWith("Attribute"))
                     .Select(header => row.GetField<string>(header))
                     .Where(value => !string.IsNullOrWhiteSpace(value))
					 .ToList()
            );
        }
    }

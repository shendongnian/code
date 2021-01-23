    public sealed class PersonMap : CsvClassMap<Person>
    {
        private List<string> attributeColumns = 
            new List<string> { "Attribute1", "Attribute2", "Attribute3" };
        public override void CreateMap()
        {
            Map(m => m.FirstName).Name("FirstName").Index(0);
            Map(m => m.LastName).Name("LastName").Index(1);
            Map(m => m.Attributes).ConvertUsing(row =>
                attributeColumns
                    .Select(column => row.GetField<string>(column))
                    .Where(value => String.IsNullOrWhiteSpace(value) == false)
                );
        }
    }

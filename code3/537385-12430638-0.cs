    public class MyClass //TODO give better name
    {
        public MyClass(DataRow row, string field) //You could have a public static generate method if it doesn't make sense for this to be a constructor.
        {
            Field = field;
            From = row.Field<decimal>(field, DataRowVersion.Original);
            To = row.Field<decimal>(field, DataRowVersion.Current);
            ItemIds = row.Field<string>("ItemIds");
        }
        public string Field { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public string ItemIds { get; set; }
    }

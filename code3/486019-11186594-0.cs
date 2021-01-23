    [DelimitedRecord(",")]
    //[IgnoreFirst]
    [IgnoreEmptyLines()]
    public class ImportRecord
    {
        [FieldQuoted]
        [FieldTrim(TrimMode.Both)]
        public string FirstName;
        [FieldQuoted]
        [FieldTrim(TrimMode.Both)]
        public string LastName;
        [FieldQuoted]
        [FieldTrim(TrimMode.Both)]
        [FieldOptional]
        public string TestProperty;
        [FieldIgnored] // <-- this field is ignored by the FileHelpers engine
        public int[] ParsedTestProperty; 
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            engine.AfterReadRecord += engine_AfterReadRecord;
            string fileAsString = @"John, Smith, 1|2|3|4" + Environment.NewLine;
            ImportRecord[] validRecords = engine.ReadString(fileAsString);
            Assert.AreEqual("John", validRecords[0].FirstName);
            Assert.AreEqual("Smith", validRecords[0].LastName);
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, validRecords[0].ParsedTestProperty);
            Console.ReadKey();
        }
        static void engine_AfterReadRecord(EngineBase engine, AfterReadEventArgs<ImportRecord> e)
        {
            e.Record.ParsedTestProperty = e.Record.TestProperty.Split('|').Select(x => Convert.ToInt32(x)).ToArray();
        }
    }

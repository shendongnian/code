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
        [FieldDelimiter("|")] // <-- here 
        public int[] TestProperty;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            string fileAsString = @"John, Smith, 1|2|3|4" + Environment.NewLine;
            ImportRecord[] validRecords = engine.ReadString(fileAsString);
            Assert.AreEqual("John", validRecords[0].FirstName);
            Assert.AreEqual("Smith", validRecords[0].LastName);
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, validRecords[0].TestProperty);
            Console.ReadKey();
        }
    }

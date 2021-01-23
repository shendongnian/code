    [DelimitedRecord(",")]
    public class ImportRecord
    {
        public string Key;
        public string Value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            string fileAsString = @"Key1,Value1" + Environment.NewLine +
                                  @"Key2,Value2" + Environment.NewLine;
            
            ImportRecord[] validRecords = engine.ReadString(fileAsString);
            var dictionary = validRecords.ToDictionary(r => r.Key, r => r.Value);
            Assert.AreEqual(dictionary["Key1"], "Value1");
            Assert.AreEqual(dictionary["Key2"], "Value2");
            Console.ReadKey();
        }
    }

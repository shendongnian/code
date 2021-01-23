    [DelimitedRecord("|")]
    [IgnoreFirst(1)]
    public class ImportRecord
    {
        public string Id;
        public string Name;
        [FieldQuoted(QuoteMode.AlwaysQuoted, MultilineMode.AllowForRead)]
        public string Comments;
        public string Date;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<ImportRecord>();
            string input = "id|name|comments|date" + Environment.NewLine +
                                  "01|edov|bla bla bla bla|2012-01-01" + Environment.NewLine +
                                  "02|john|bla bla bla bla|2012-01-02" + Environment.NewLine +
                                  "03|Pete|bla bla" + Environment.NewLine +
                                  "bla bla|2012-03-01" + Environment.NewLine +
                                  "04|Mary|bla bla bla bla|2012-01-01";
            // Modify import to add quotes to multiline fields
            var inputSplitAtSeparator = input.Split('|');
            // Add quotes around the field after every third '|'
            var inputWithQuotesAroundCommentsField = inputSplitAtSeparator.Select((x, i) => (i % 3 == 2) ? "\"" + x + "\"" : x);
            var inputJoinedBackTogether = String.Join("|", inputWithQuotesAroundCommentsField);
            ImportRecord[] validRecords = engine.ReadString(inputJoinedBackTogether);
            // Check the third record
            Assert.AreEqual("03", validRecords[2].Id);
            Assert.AreEqual("Pete", validRecords[2].Name);
            Assert.AreEqual("bla bla" + Environment.NewLine + "bla bla", validRecords[2].Comments);
            Assert.AreEqual("2012-03-01", validRecords[2].Date);
            Console.WriteLine("All assertions passed");
            Console.ReadKey();
        }
    }

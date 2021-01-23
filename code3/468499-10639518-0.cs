    [DelimitedRecord(",")]
    public class MyClass
    {
        public string Field1;
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForRead)]
        public string ExchangeRate;
        public string Field3;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<MyClass>();
            string fileAsString = @"a,b,c" + Environment.NewLine +
                                  @"a,b,c" + Environment.NewLine + 
                                  @"a,""b,c"",d";
            MyClass[] validRecords = engine.ReadString(fileAsString);
            // Check the ExchangeRate values for rows 0, 1, 2 are as expected
            Assert.AreEqual("b", validRecords[0].ExchangeRate);
            Assert.AreEqual("b", validRecords[1].ExchangeRate);
            Assert.AreEqual("b,c", validRecords[2].ExchangeRate);
            Console.ReadKey();
        }
    }

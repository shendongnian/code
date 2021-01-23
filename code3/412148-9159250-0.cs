    class Program
    {
        [DelimitedRecord(",")]
        [IgnoreFirst(1)]
        public class Format1
        {
            [FieldQuoted]
            [FieldConverter(ConverterKind.Date, "d/M/yyyy")]
            public DateTime Date;
            [FieldQuoted]
            public string Description;
            [FieldQuoted]
            public string OriginalDescription;
            [FieldQuoted]
            public Decimal Amount;
            [FieldQuoted]
            public string Type;
            [FieldQuoted]
            public string Category;
            [FieldQuoted]
            public string Name;
            [FieldQuoted]
            public string Labels;
            [FieldQuoted]
            [FieldOptional]
            public string Notes;
        }
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine(typeof(Format1));
            // read in the data   
            object[] importedObjects = engine.ReadString(@"""Date"",""Description"",""Original Description"",""Amount"",""Type"",""Category"",""Name"",""Labels"",""Notes""
    ""2/02/2012"",""ac"",""ac"",""515.00"",""a"",""b"","""",""javascript://""
    ""2/02/2012"",""test"",""test"",""40.00"",""a"",""d"",""c"","""","" """);
            // check that 2 records were imported
            Assert.AreEqual(2, importedObjects.Length);
            
            // check the values for the first record
            Format1 customer1 = (Format1)importedObjects[0];
            Assert.AreEqual(DateTime.Parse("2/02/2012"), customer1.Date);
            Assert.AreEqual("ac", customer1.Description);
            Assert.AreEqual("ac", customer1.OriginalDescription);
            Assert.AreEqual(515.00, customer1.Amount);
            Assert.AreEqual("a", customer1.Type);
            Assert.AreEqual("b", customer1.Category);
            Assert.AreEqual("", customer1.Name);
            Assert.AreEqual("javascript://", customer1.Labels);
            Assert.AreEqual("", customer1.Notes);
            // check the values for the second record
            Format1 customer2 = (Format1)importedObjects[1];
            Assert.AreEqual(DateTime.Parse("2/02/2012"), customer2.Date);
            Assert.AreEqual("test", customer2.Description);
            Assert.AreEqual("test", customer2.OriginalDescription);
            Assert.AreEqual(40.00, customer2.Amount);
            Assert.AreEqual("a", customer2.Type);
            Assert.AreEqual("d", customer2.Category);
            Assert.AreEqual("c", customer2.Name);
            Assert.AreEqual("", customer2.Labels);
            Assert.AreEqual(" ", customer2.Notes);
        }
    }

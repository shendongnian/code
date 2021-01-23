    [DelimitedRecord(",")]
    public partial class Person
    {
        public string FirstName;
        public string LastName;
        [FieldOptional]
        public string Optional1;
        [FieldOptional]
        public string Optional2;
        [FieldOptional]
        public string Optional3;
    }      
    class Program
    {
        private static void Main(string[] args)
        {
            var engine = new FileHelperEngine<Person>();
            engine.AfterWriteRecord += engine_AfterWriteRecord;
            var export = engine.WriteString(
                         new Person[] { 
                           new Person() { FirstName = "Joe", LastName = "Bloggs" } 
                         });
            Assert.AreEqual("Joe,Bloggs" + Environment.NewLine, export);
        }
        static void engine_AfterWriteRecord(EngineBase engine, AfterWriteEventArgs<Person> e)
        {
            // trim trailing empty separators
            e.RecordLine = e.RecordLine.TrimEnd(',');
        }
    }

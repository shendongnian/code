    [DelimitedRecord("|")]
    public class MyClass
    {
        public string Field1;
        public string Field2;
        public string Field3;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<MyClass>();
            engine.AfterReadRecord += new FileHelpers.Events.AfterReadHandler<MyClass>(engine_AfterReadRecord);
            engine.ErrorMode = ErrorMode.SaveAndContinue;
            // import a record with an invalid Email
            MyClass[] validRecords = engine.ReadString("Hello||World");
            ErrorInfo[] errors = engine.ErrorManager.Errors;
            Assert.AreEqual(1, engine.TotalRecords); // 1 record was processed
            Assert.AreEqual(0, validRecords.Length); // 0 records were valid
            Assert.AreEqual(1, engine.ErrorManager.ErrorCount); // 1 error was found
            Assert.That(errors[0].ExceptionInfo.Message == "Field2 is invalid");
        }
        static void engine_AfterReadRecord(EngineBase engine, FileHelpers.Events.AfterReadEventArgs<MyClass> e)
        {
            if (String.IsNullOrWhiteSpace(e.Record.Field1))
                throw new Exception("Field1 is invalid");
            if (String.IsNullOrWhiteSpace(e.Record.Field2))
                throw new Exception("Field2 is invalid");
            if (String.IsNullOrWhiteSpace(e.Record.Field3))
                throw new Exception("Field3 is invalid");
        }
    }

    [DelimitedRecord("|")]
    public class MyClass
    {
        public string Field1 { get; set; }
        public int Field2 { get; set; }
        public string Email { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<MyClass>();
            engine.AfterReadRecord += new FileHelpers.Events.AfterReadHandler<MyClass>(engine_AfterReadRecord);
            engine.ErrorMode = ErrorMode.SaveAndContinue;
            // import a record with an invalid Email
            MyClass[] validRecords = engine.ReadString("Hello|23|World");
            ErrorInfo[] errors = engine.ErrorManager.Errors;
            Assert.AreEqual(1, engine.TotalRecords); // 1 record was processed
            Assert.AreEqual(0, validRecords.Length); // 0 records were valid
            Assert.AreEqual(1, engine.ErrorManager.ErrorCount); // 1 error was found
            Assert.That(errors[0].ExceptionInfo.Message == "Email is invalid");
        }
        static bool IsEmailValid(string email)
        {
            return false;
        }
        static void engine_AfterReadRecord(EngineBase engine, FileHelpers.Events.AfterReadEventArgs<MyClass> e)
        {
            bool isEmailValid = IsEmailValid(e.Record.Email);
            if (!isEmailValid)
            {
                throw new Exception("Email is invalid");
            }
        }
    }

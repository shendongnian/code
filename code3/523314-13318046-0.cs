    public class XUnitTheoryStackTraceParser : XUnitStackTraceParser
    {
        public const string TheoryAttribute = "Xunit.Extensions.TheoryAttribute";
        protected override string GetAttributeType()
        {
            return TheoryAttribute;
        }
    }
    public class ApproveTheoryTest
    {
        static ApproveTheoryTest()
        {
            StackTraceParser.AddParser(new XUnitTheoryStackTraceParser());
        }
        
        [Theory]
        [UseReporter(typeof(DiffReporter))]
        [InlineData("file1.txt")]
        [InlineData("file2.txt")]
        public void approve_file(string fileName)
        {
            NamerFactory.AdditionalInformation = fileName;
            Approvals.Verify("sample text");
        }
    }

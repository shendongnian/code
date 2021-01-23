    public interface ITextReader {
        string ReadLine();
    }
    public interface ICsvParser {
        string[] GetColumns(string line);
    }
    public class CSV {
        private readonly ITextReader textReader;
        private readonly ICsvParser csvParser;
        public CSV(ITextReader textReader, ICsvParser csvParser) {
             this.textReader = textReader;
             this.csvParser = csvParser;
        }
        public string[] GetColumns() {                       
            string[] columns = null;
            var line = this.textReader.ReadLine();			
            if (!string.IsNullOrEmpty(line)){
               columns = this.csvParser.GetColumns(line);              
            }
            return columns;
        }
    }
    [TestClass]
    public class CSVFixture {
        private Mock<ITextReader> mockTextReader;
        private Mock<ICsvParser> mockCsvParser;
        private CSV csv;
			
        private readonly static string [] Columns = new string[]{};
        [TestInitialize]
        public void Setup() {
            mockTextReader = new Mock<ITextReader>();
            mockCsvParser = new Mock<ICsvParser>();
            csv = new CSV(mockTextReader.Object, mockCsvParser.Object);
        }
        [TestMethod]
        public void NullLine() {
            Execute(null);
        }
        [TestMethod]
        public void EmptyLine() {
            Execute("");
        }
        [TestMethod]
        public void PopulatedLine() {
            Execute("SomeLineValue", Columns);
        }
        private void Execute(string line, string[] expected = null) {
            mockTextReader.Setup(mk => mk.ReadLine()).Returns(line);
            mockCsvParser.Setup(mk => mk.GetColumns(line)).Returns(Columns);
            var actual = csv.GetColumns();
            Assert.AreEqual(actual, expected);
        }
    }

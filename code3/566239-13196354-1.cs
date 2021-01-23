    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class PdfFieldName : System.Attribute
    {
        public string Name;
        public PdfFieldName(string name)
        {
            Name = name;
        }
    }
    public class test
    {
        [PdfFieldName("TextBox Name")]
        public string TextBoxName { get; set; }
    }
    private static void Main(string[] args)
    {
        Dictionary<string, string> fields = new Dictionary<string, string> {{"TextBox Name", "Natan"}};
        test genericClass = new test() {TextBoxName = "Nathan"};
        UpdatePdfDocument(OLD_PDF_DOCUMENT_PATH, NEW_PDF_DOCUMENT_PATH, genericClass, true);
    }

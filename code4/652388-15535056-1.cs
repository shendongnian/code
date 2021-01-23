    namespace PDF.API
    {
        public class PDFDocument
        {
            private PDDocument PD;
    
            public PDFDocument()
            { //class constructor
            }
    
            public void load(string PDFPath)
            {
                PD = PDDocument.load(PDFPath);
            }
            // ...
        }
    }

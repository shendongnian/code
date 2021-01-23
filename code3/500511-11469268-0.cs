    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    
    namespace pdfreadertest
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                GetTextFromPDFFile(@"c:\example.pdf", 1);
            }
    
            public void GetTextFromPDFFile(string pdfFile, int pageNumber)
            {
                // Call the reader to read the pdf file
                PdfReader pdfReader = new PdfReader(pdfFile);
    
                // Extract the text from the pdf reader and put into a string
                string pdfText = PdfTextExtractor.GetTextFromPage(pdfReader, pageNumber);
    
                // Try and close the reader
                try
                {
                    pdfReader.Close();
                }
                catch{ }
    
                // Put the string (pdf text) into a label to display on page
                this.lblPdfText.Text = pdfText;
            }
        }
    }

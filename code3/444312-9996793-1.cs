    using System;
    using System.IO;
    using System.Windows.Forms;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
                //Test file to create
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
                //Standard PDF file stream creation
                using (FileStream output = new FileStream(outputFile, FileMode.Create,FileAccess.Write,FileShare.None)){
                    using (Document document = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(document, output)) {
    
                            //Bind our custom event handler to the PdfWriter
                            writer.PageEvent = new MyPageEventHandler();
                            //Open our PDF for writing
                            document.Open();
    
                            //Add some text to page 1
                            document.Add(new Paragraph("This is page 1"));
                            //Add a new page
                            document.NewPage();
                            //Add some text to page 2
                            document.Add(new Paragraph("This is page 2"));
    
                            //Close the PDF
                            document.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
        public class MyPageEventHandler : iTextSharp.text.pdf.PdfPageEventHelper {
            public override void OnEndPage(PdfWriter writer, Document document) {
                //Create a simple ColumnText object
                var CT = new ColumnText(writer.DirectContent);
                //Bind it to the top of the document but take up the entire page width
                CT.SetSimpleColumn(0, document.PageSize.Height - 20, document.PageSize.Width, document.PageSize.Height);
                //Add some text
                CT.AddText(new Phrase("This is a test"));
                //Draw our ColumnText object
                CT.Go();
            }
        }
    }

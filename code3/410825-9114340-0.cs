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
                //Files that we'll be working with
                string inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "aa.pdf");
                string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "bb.pdf");
    
                //Create a standard PDF to test with, nothing special here
                using (FileStream fs = new FileStream(inputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document doc = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
    
                            //Create 10 pages with labels on each page
                            for (int i = 1; i <= 10; i++) {
                                doc.NewPage();
                                doc.Add(new Paragraph(String.Format("This is page {0}", i)));
                            }
    
                            doc.Close();
                        }
                    }
                }
    
                //For the OP, this is where you would start
    
    
                //Declare some variables to be used later
                ColumnText ct;
                Chunk c;
    
                //Bind a reader to the input file
                PdfReader reader = new PdfReader(inputFile);
                //PDFs don't automatically make hyperlinks a special color so we're specifically creating a blue font to use here
                iTextSharp.text.Font BlueFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLUE);
    
                //Create our new file
                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    //Bind a stamper to our reader and output file
                    using (PdfStamper stamper = new PdfStamper(reader, fs)) {
    
                        Chunk ch = new Chunk("Go to next page").SetAction(new PdfAction(PdfAction.NEXTPAGE));
    
                        //Get the "over" content for page 1
                        PdfContentByte cb = stamper.GetOverContent(1);
    
                        //This example adds a link that goes to the next page
                        //Create a ColumnText object
                        ct = new ColumnText(cb);
                        //Set the rectangle to write to
                        ct.SetSimpleColumn(0, 0, 200, 20);
                        //Add some text and make it blue so that it looks like a hyperlink
                        c = new Chunk("Go to next page", BlueFont);
                        //Set the action to go to the next page
                        c.SetAction(new PdfAction(PdfAction.NEXTPAGE));
                        //Add the chunk to the ColumnText
                        ct.AddElement(c);
                        //Tell the system to process the above commands
                        ct.Go();
    
                        //This example add a link that goes to a specific page number
                        //Create a ColumnText object
                        ct = new ColumnText(cb);
                        //Set the rectangle to write to
                        ct.SetSimpleColumn(200, 0, 400, 20);
                        //Add some text and make it blue so that it looks like a hyperlink
                        c = new Chunk("Go to page 3", BlueFont);
                        //Set the action to go to a specific page number. This option is a little more complex, you also have to specify how you want to "fit" the document
                        c.SetAction(PdfAction.GotoLocalPage(3, new PdfDestination(PdfDestination.FIT), stamper.Writer));
                        //Add the chunk to the ColumnText
                        ct.AddElement(c);
                        //Tell the system to process the above commands
                        ct.Go();
                    }
                }
    
                this.Close();
            }
        }
    }

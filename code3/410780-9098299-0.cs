    using System;
    using System.Collections.Generic;
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
                //File with meta data added
                string InputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
                //File with meta data removed
                string OutputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
    
                //Create a file with meta data, nothing special here
                using (FileStream FS = new FileStream(InputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document Doc = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(Doc, FS)) {
                            Doc.Open();
                            Doc.Add(new Paragraph("Test"));
                            //Add a standard header
                            Doc.AddTitle("This is a test");
                            //Add a custom header
                            Doc.AddHeader("Test Header", "This is also a test");
                            Doc.Close();
                        }
                    }
                }
    
                //Read our newly created file
                PdfReader R = new PdfReader(InputFile);
                //Loop through each piece of meta data and remove it
                foreach (KeyValuePair<string, string> KV in R.Info) {
                    R.Info.Remove(KV.Key);
                }
    
                //The code above modifies an in-memory representation of the PDF, we need to write these changes to disk now
                using (FileStream FS = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document Doc = new Document()) {
                        //Use the PdfCopy object to copy each page
                        using (PdfCopy writer = new PdfCopy(Doc, FS)) {
                            Doc.Open();
                            //Loop through each page
                            for (int i = 1; i <= R.NumberOfPages; i++) {
                                //Add it to the new document
                                writer.AddPage(writer.GetImportedPage(R, i));
                            }
                            Doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }

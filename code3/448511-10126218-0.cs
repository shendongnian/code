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
                //Folder that we'll work from
                string workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string pdf1 = Path.Combine(workingFolder, "pdf1.pdf");//PDF with solid red background color
                string pdf2 = Path.Combine(workingFolder, "pdf2.pdf");//PDF with text
                string pdf3 = Path.Combine(workingFolder, "pdf3.pdf");//Merged PDF
    
                //Create a basic PDF filled with red, nothing special
                using (FileStream fs = new FileStream(pdf1, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document doc = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
                            PdfContentByte cb = writer.DirectContent;
                            cb.SetColorFill(BaseColor.RED);
                            cb.Rectangle(0, 0, doc.PageSize.Width, doc.PageSize.Height);
                            cb.Fill();
                            doc.Close();
                        }
                    }
                }
    
                //Create a basic PDF with a single line of text, nothing special
                using (FileStream fs = new FileStream(pdf2, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document doc = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
                            doc.Add(new Paragraph("This is a test"));
                            doc.Close();
                        }
                    }
                }
    
                //Create a basic PDF
                using (FileStream fs = new FileStream(pdf3, FileMode.Create, FileAccess.Write, FileShare.None)) {
                    using (Document doc = new Document(PageSize.LETTER)) {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs)) {
                            doc.Open();
    
                            //Get page 1 of the first file
                            PdfImportedPage imp1 = writer.GetImportedPage(new PdfReader(pdf1), 1);
                            //Get page 2 of the second file
                            PdfImportedPage imp2 = writer.GetImportedPage(new PdfReader(pdf2), 1);
                            //Add the first file to coordinates 0,0
                            writer.DirectContent.AddTemplate(imp1, 0, 0);
                            //Since we don't call NewPage the next call will operate on the same page
                            writer.DirectContent.AddTemplate(imp2, 0, 0);
                            doc.Close();
                        }
                    }
                }
    
                this.Close();
            }
        }
    }

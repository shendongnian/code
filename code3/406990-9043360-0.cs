    // Add reference to iTextSharp.dll. Freely available on the web. Free to use.
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.xml;
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                // Original Pdf
                string PDFFile = "C:\\MyOriginalPDF.pdf";
            
                // New Pdf
                string newPDFFile = "C:\\NewPDFFILE.pdf";
                PdfReader pdfReader = new PdfReader(PDFFile);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newPDFFile, FileMode.Create));
                AcroFields pdfFFields = pdfStamper.AcroFields;
                // Fill PDF Form Fields
                pdfFFields.SetField("FieldName1", "Value1");
                pdfFFields.SetField("FieldName2", "Value2");
                //
                // And So on
            
                // Use this to remove editting options by setting it to false
                // To keep editing option leave it as TRUE
                pdfStamper.FormFlattening = true;
                // close the pdf
                pdfStamper.Close();
            }
        }
    }

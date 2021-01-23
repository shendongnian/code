    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using PdfSharp.Fonts;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    using PdfSharp.Pdf.AcroForms;
    
    namespace PDFSharpTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void goButton_Click(object sender, EventArgs e)
            {
                //TestPDF();  //uncomment this to find out whether acroform will work correctly         
    
                //open file
                PdfDocument pdf = PdfReader.Open(@"YOURFILEPATHandNAME", PdfDocumentOpenMode.Modify);
                
                //fix some odd setting where filled fields don't always show                   SetupPDF(pdf);
                
                //find and fill fields
                PdfTextField txtEmployerName = (PdfTextField)(pdf.AcroForm.Fields["txtEmployerName"]);
                txtEmployerName.Value = new PdfString("My Name");
    
                PdfTextField txtEmployeeTitle = (PdfTextField)(pdf.AcroForm.Fields["txtEmployeeTitle"]);
                txtEmployeeTitle.Value = new PdfString("Workin'");
    
                PdfCheckBoxField chxAttached = (PdfCheckBoxField)(pdf.AcroForm.Fields["chxAttached"]);
                chxAttached.Checked = true;
    
                //save file
                pdf.Save(@"NEWFILEPATHandNAMEHERE");
            }
    
            private void SetupPDF(PdfDocument pdf)
            {
                if (pdf.AcroForm.Elements.ContainsKey("/NeedAppearances") == false)
                {
                    pdf.AcroForm.Elements.Add("/NeedAppearances", new PdfSharp.Pdf.PdfBoolean(true));
                }
                else
                {
                    pdf.AcroForm.Elements["/NeedAppearances"] = new PdfSharp.Pdf.PdfBoolean(true);
                }
            }
    
            private void PDFTest()
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument _document = null;
                    try { _document = PdfReader.Open(ofd.FileName, PdfDocumentOpenMode.Modify); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "FATAL");             //do any cleanup and return             
                        return;
                    }
                    if (_document != null)
                    {
                        if (_document.AcroForm != null)
                        {
                            MessageBox.Show("Acroform is object", "SUCCEEDED");
                            //pass acroform to some function for processing          
                            _document.Save(@"C:\temp\newcopy.pdf");
                        }
                        else
                        {
                            MessageBox.Show("Acroform is null", "FAILED");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unknown error opening document", "FAILED");
                    }
                }
            }
        }
    }
     
           
    

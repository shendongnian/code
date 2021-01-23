    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using DocumentFormat.OpenXml.Packaging;
    using System.IO;
    using System.Threading;
    namespace TestReportCreator_Beta
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [STAThread]
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string outFile = @"C:\Users\Christopher\Desktop\BookData\TestReportBetaEND.docx";
            
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            OFD.Title = "Open Word Document";
            OFD.Filter = "Word Document|*.docx;*.domx";
            OFD.ShowDialog();
            string docPath = OFD.FileName;
            OFD.Title = "Opne Xml Document";
            OFD.Filter = "Xml Document|*.xml";
            OFD.ShowDialog();
            string xmlPath = OFD.FileName;
            // convert template to document
            File.Copy(docPath, outFile);
            using (WordprocessingDocument doc = WordprocessingDocument.Open(outFile, true))
            {
                MainDocumentPart mdp = doc.MainDocumentPart;
                if (mdp.CustomXmlParts != null)
                {
                    mdp.DeleteParts<CustomXmlPart>(mdp.CustomXmlParts);
                }
                CustomXmlPart cxp = mdp.AddCustomXmlPart(CustomXmlPartType.CustomXml);
                FileStream fs = new FileStream(xmlPath, FileMode.Open);
                cxp.FeedData(fs);
                mdp.Document.Save();
            } 
        }
    }
    }

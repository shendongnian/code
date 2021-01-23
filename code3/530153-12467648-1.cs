    using System; using System.Collections.Generic;
    using System.Linq; using System.Text;
    using DocumentFormat.OpenXml; using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing; using System.IO;
    namespace BookData
    {
    class Program
    {
        static void Main(string[] args)
        {
            string template = @"C:\Users\Christopher\Desktop\BookData\TestReportBeta.docx";
            string outFile = @"C:\Users\Christopher\Desktop\BookData\TestReportBetaEND.docx";
            string xmlPath = @"C:\Users\Christopher\Desktop\BookData\TestReport.xml";
            // convert template to document
            File.Copy(template, outFile);
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

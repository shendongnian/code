    using System;
    using System.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    namespace WordProcessingEx
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string fileName = /*obtain path to file here*/;
                using (WordprocessingDocument myDocument = WordprocessingDocument.Open(fileName, true))
                {
                    // Get all paragraphs
                    var p = myDocument.MainDocumentPart.Document.Body.Elements<Paragraph>().First();
                    var r = from para in p
                            from run in para.Elements<Run>()
                            where run.RunProperties.RunFonts.ASCII ="NeededFont" || run.RunProperties.RunFonts.HighAnsi = "NeededFont"
                            select run;
                }
            }
        }
    }

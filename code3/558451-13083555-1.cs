    using System;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Wordprocessing;
    
    namespace OpenXML
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var doc = WordprocessingDocument.Create("C:\\Subscript.docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
    
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph p = body.AppendChild(new Paragraph());
    
                    p.AppendChild(AddRun(false, "Some text   b "));
                    p.AppendChild(AddRun(true, "eff"));
                    p.AppendChild(AddRun(false, "= 3.0"));
                }
    
                Console.WriteLine("Done...");
                Console.ReadLine();
            }
    
            public static Run AddRun(bool isSubscript, string text)
            {
                Run run = new Run();
                if (isSubscript)
                {
                    var props = new RunProperties();
                    var fontSize = new FontSizeComplexScript() { Val = "20" };
                    var vAlignment = new VerticalTextAlignment() { Val = VerticalPositionValues.Subscript };
    
                    props.Append(fontSize);
                    props.Append(vAlignment);
                    run.Append(props);
                }
                run.Append(new Text(text));
                return run;
            }
        }
    }

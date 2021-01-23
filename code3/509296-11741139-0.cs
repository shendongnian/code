    using System;
    using Microsoft.Office.Interop.Word;
    
    namespace PageSetup
    {
        class TestPageOrientation
        {
            static void Main(string[] args)
            {
                var app = new Microsoft.Office.Interop.Word.Application();
                app.Visible = true;
    
                //Load Document
                Document document = app.Documents.Open(@"C:\Temp\myDocument.docx");
    
                // I've added this rows below. ...And that works
                document.Sections.First.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                document.Sections.Last.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
    
                // ... and this. But the LeftMargin I can leave it.
                document.PageSetup.LeftMargin = 1.00F;
                document.Save();
            }
        }
    }

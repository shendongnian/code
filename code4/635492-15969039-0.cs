    public static void FormatImages()
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            string filePath = @"C:\Users\newton.sheikh\Documents\Visual Studio 2010\Projects\MSOffice\OpenXML\OpenXML\Temp.docx";
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(filePath, false);
            object save_changes = false;
            foreach (Microsoft.Office.Interop.Word.InlineShape item in wordApp.ActiveDocument.InlineShapes)
            {
                if (item != null)
                {
                    if (item.Type == Microsoft.Office.Interop.Word.WdInlineShapeType.wdInlineShapePicture)
                    {
                        item.Select();
                        Microsoft.Office.Interop.Word.Shape shape = item.ConvertToShape();
                        shape.WrapFormat.Type = WdWrapType.wdWrapFront;
                    }
                }
            }
            doc.SaveAs(@"C:\Users\newton.sheikh\Documents\Visual Studio 2010\Projects\MSOffice\OpenXML\OpenXML\RetailWrite.docx");
            doc.Close(save_changes);
            wordApp.Quit(save_changes);
            if (System.IO.File.Exists(@"C:\Users\newton.sheikh\Documents\Visual Studio 2010\Projects\MSOffice\OpenXML\OpenXML\Temp.docx"))
            {
                System.IO.File.Delete(@"C:\Users\newton.sheikh\Documents\Visual Studio 2010\Projects\MSOffice\OpenXML\OpenXML\Temp.docx");
            }
        }

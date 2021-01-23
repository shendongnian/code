    object fileName = "C:\\Template_1.docx";
    string workbookPath = "C:\\Book1.xlsx";
    Excel.Workbook wb = Globals.ThisAddIn.Application.Workbooks.Add(workbookPath);
    Excel.Worksheet ws = wb.Worksheets[1];
    ws.Range["A1:D4"].Copy();
                    
    object missing = System.Reflection.Missing.Value;
    Word.Application wordApp = Marshal.GetActiveObject("Word.Application") as Word.Application;
    Word.Document doc;
    Word.Range rng;
    doc = wordApp.ActiveDocument;
    rng = wordApp.Selection.Range;
    object objDataTypeMetafile = Word.WdPasteDataType.wdPasteRTF;
    rng.PasteSpecial(ref missing, ref missing,
    ref missing, ref missing, ref objDataTypeMetafile,
    ref missing, ref missing);

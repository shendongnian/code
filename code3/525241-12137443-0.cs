            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
           //TT Excel.Range range;
            object misValue = System.Reflection.Missing.Value;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
          
                // open excel 
                xlApp = new Excel.ApplicationClass();
                //Change THE LOCATION!
                xlWorkBook = xlApp.Workbooks.Open("C:\\Documents and Settings\\Student\\Desktop\\ExportFiles\\Excel.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet=(Excel.Worksheet)xlWorkBook.ActiveSheet;
              
               
            
                // open word 
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
               
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = "Snimeno na:" + " " + dt+"\n";
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();
                xlWorkSheet.get_Range("A1", "N49").Copy(Missing.Value);
                oWord.Selection.Paste();
                oWord.Selection.TypeParagraph();
               //The textBox is for the name of the new Word document
                if (TextBox1.Text == "")
                    TextBox1.Text = "Document1";
             object fileName = @"C:\\Documents and Settings\\Student\\Desktop\\ExportFiles\\"+TextBox1.Text+".docx"; 
                
                oDoc.SaveAs(ref fileName,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
 
             

            List<Word.Range> TablesRanges = new List<Word.Range>();
            wordApp = new Microsoft.Office.Interop.Word.Application();
            doc = wordApp.Documents.OpenNoRepairDialog(FileName: @"c:\AAAAA.docx", ConfirmConversions: false, ReadOnly: true, AddToRecentFiles: false, NoEncodingDialog: true);
            for (int iCounter = 1; iCounter <= doc.Tables.Count; iCounter++)
            {
                Word.Range TRange = doc.Tables[iCounter].Range;
                TablesRanges.Add(TRange);
            }
            Boolean bInTable;
            for (int par = 1; par <= doc.Paragraphs.Count; par++)
            {
                bInTable = false;
                Word.Range r = doc.Paragraphs[par].Range;
                foreach (Word.Range range in TablesRanges)
                {
                    if (r.Start >= range.Start && r.Start <= range.End)
                    {
                        Console.WriteLine("In Table - Paragraph number " + par.ToString() + ":" + r.Text);
                        bInTable = true;
                        break;
                    }
                        
                }
                if (!bInTable)
                    Console.WriteLine("!!!!!! Not In Table - Paragraph number " + par.ToString() + ":" + r.Text);
            }

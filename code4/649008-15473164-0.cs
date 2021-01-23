    doc.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageFooter;
                    Object oMissing = System.Reflection.Missing.Value;
                    doc.ActiveWindow.Selection.TypeText("some text \t Page ");
                    Object TotalPages = Microsoft.Office.Interop.Word.WdFieldType.wdFieldNumPages;
                    Object CurrentPage = Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage;
                    doc.ActiveWindow.Selection.Fields.Add(doc.ActiveWindow.Selection.Range, ref CurrentPage, ref oMissing, ref oMissing);
                    doc.ActiveWindow.Selection.TypeText(" of ");
                    doc.ActiveWindow.Selection.Fields.Add(doc.ActiveWindow.Selection.Range, ref TotalPages, ref oMissing, ref oMissing);

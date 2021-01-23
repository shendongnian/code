          Word.Application wordApp = new Word.Application();
          Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref outputFile, ref oMissing,
                         ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                         ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                         ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    doc.Activate();
                  try
                    {
                        //----------------------Replace--------------------------------
                        Microsoft.Office.Interop.Word.Find fnd = wordApp.ActiveWindow.Selection.Find;
                        fnd.ClearFormatting();
                        fnd.Replacement.ClearFormatting();
                        fnd.Forward = true;
                        fnd.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
        
        string imagePath = Server.MapPath("~/data/uploads/violations/resize/Image.jpg");
        var keyword = "LOGO";
                            var sel = wordApp.Selection;
                            sel.Find.Text = string.Format("[{0}]", keyword);
        wordApp.Selection.Find.Execute(keyword);
        
                            Word.Range range = wordApp.Selection.Range;
         if (range.Text.Contains(keyword))
                                {
                                    //gets desired range here it gets last character to make superscript in range 
                                    Word.Range temprange = doc.Range(range.End - 4, range.End);//keyword is of 4 charecter range.End - 4
                                    temprange.Select();
                                    Word.Selection currentSelection = wordApp.Selection;
                                    //currentSelection.Font.Superscript = 1;
        
                                    sel.Find.Execute(Replace: WdReplace.wdReplaceOne);
                                    sel.Range.Select();
                                    var imagePath1 = Path.GetFullPath(string.Format(imagePath, keyword));
                                    sel.InlineShapes.AddPicture(FileName: imagePath1, LinkToFile: false, SaveWithDocument: true);
         }
    }
    catch { }
                finally
                {
                    if (doc != null)
                    {
                        ((_Document)doc).Close(ref oMissing, ref oMissing, ref oMissing);
                        Marshal.FinalReleaseComObject(doc);
                    }
                    if (wordApp != null)
                    {
                        ((_Application)wordApp).Quit();
                        Marshal.FinalReleaseComObject(wordApp);
                    }
                }

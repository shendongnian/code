     public static void FindFootnoteInDocument(Word.Document doc)
            {
         foreach (Microsoft.Office.Interop.Word.Footnote paragraph in doc.Footnotes)
                    {
                        paragraph.Range.Select();
                        Microsoft.Office.Interop.Word.Style style1 = paragraph.Application.Selection.get_Style() as Microsoft.Office.Interop.Word.Style;
                        string styleName1;
                        if (style1 != null)
                            styleName1 = style1.NameLocal;
                        else
                            styleName1 = "Footnote Text";
                        int range = paragraph.Range.Start;
                        Word.Range ty = APIWrapper.APIUtility.GetWordRange(doc.Name, paragraph.Range.Start, paragraph.Range.End);
                        object unit = Word.WdUnits.wdWord;
                        object count = 1;
                        object extend = Word.WdMovementType.wdMove;
                        int t = paragraph.Application.Selection.Range.Move(ref unit, ref count);
                        string text = paragraph.Range.Text;
                        if (styleName1 == "Footnote Text")
                        {
                            Word.Selection currentSelection = doc.Application.Selection;
                            currentSelection.Find.ClearFormatting();
                            object style = "Footnote Text";
                            currentSelection.Find.set_Style(ref style);
                            var _with1 = currentSelection.Find;
                            _with1.Text = "";
                            _with1.Replacement.Text = "";
                            _with1.Forward = true;
                            _with1.Wrap = Word.WdFindWrap.wdFindContinue;
                            _with1.Format = true;
                            _with1.MatchCase = false;
                            _with1.MatchWholeWord = false;
                            _with1.MatchWildcards = false;
                            _with1.MatchSoundsLike = false;
                            _with1.MatchAllWordForms = false;
                            currentSelection.Cut();
                            object Count1 = 1;
                            object Unit1 = WdUnits.wdLine;
                            object Extend1 = WdMovementType.wdExtend;
                     
                            doc.Application.Selection.MoveUp(ref Unit, ref Count, ref missing);
                            currentSelection.Find.Execute();//Execute()
                            while (currentSelection.Find.Found)
                            {
                               currentSelection.Range.Select();
                             string textvalue = currentSelection.Range.Text;
                             r2.Text = textvalue;
       	        MessageBox.Show("Sent lines :" + currentSelection.Text.ToString());
                              r2.set_Style(ref style);
                             break;  
                            }
                        }
                    }
                    break;
                }
            }

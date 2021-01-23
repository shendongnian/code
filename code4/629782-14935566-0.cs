      foreach (Microsoft.Office.Interop.Word.Footnote x in doc.Footnotes)
                    {
                        //MessageBox.Show(x.Range.Text);
    
                        object selStart = x.Range.Start;
                        object selEnd = x.Range.End;
                        object missing = Type.Missing;
                        object footnote = x.Range.Text;
                        Range range = doc2.Range(ref selStart, ref selEnd);
                        doc2.Footnotes.Add(range, ref missing, x.Range.Text);
                    }

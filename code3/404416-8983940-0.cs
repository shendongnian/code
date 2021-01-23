                        Microsoft.Office.Interop.Word.Table table = b.Range.Tables[1];
                    table.ID = b.Name;
                    for (int colCounter = 1; colCounter <= masterTable.Columns.Count; colCounter++)
                    {
                        Microsoft.Office.Interop.Word.Range sourceRange = masterTable.Cell(1, colCounter).Range;
                        Microsoft.Office.Interop.Word.Range targetRange = table.Cell(1, colCounter).Range;
                        object oCharacter = Microsoft.Office.Interop.Word.WdUnits.wdCharacter;
                        object negOne = -1;
                        sourceRange.MoveEnd(oCharacter, negOne);
                        targetRange.MoveEnd(oCharacter, negOne);
                        targetRange.FormattedText = sourceRange.FormattedText;
                    }
 

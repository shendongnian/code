    List<string> listShared = new List<string>();
    using (SpreadsheetDocument xl = SpreadsheetDocument.Open("YourFile.xlsx", false))
    {
        SharedStringItem ssi;
        using (OpenXmlReader oxrShared = OpenXmlReader.Create(xl.WorkbookPart.SharedStringTablePart))
        {
            while (oxrShared.Read())
            {
                if (oxrShared.ElementType == typeof(SharedStringItem))
                {
                    ssi = (SharedStringItem)oxrShared.LoadCurrentElement();
                    // this assumes the shared string is a simple text format, instead of rich text.
                    listShared.Add(ssi.Text.Text);
                }
            }
        }
    
        WorksheetPart wsp = xl.WorkbookPart.WorksheetParts.First();
        Cell c;
        using (OpenXmlReader oxrCells = OpenXmlReader.Create(wsp))
        {
            while (oxrCells.Read())
            {
                if (oxrCells.ElementType == typeof(Cell))
                {
                    c = (Cell)oxrCells.LoadCurrentElement();
                    // c.CellReference holds a string such as "A1"
                    if (c.DataType != null)
                    {
                        if (c.DataType == CellValues.SharedString)
                        {
                            // use whichever from-string-to-number conversion
                            // you like.
                            //listShared[Convert.ToInt32(c.CellValue.Text)];
                        }
                        else if (c.DataType == CellValues.Number)
                        {
                            // "normal" value
                            //c.CellValue.Text;
                        }
                        // there's also boolean, which you might be interested
                        // as well as other types
                    }
                    else
                    {
                        // is by default a Number. Use this:
                        //c.CellValue.Text;
                    }
                }
            }
        }
    }

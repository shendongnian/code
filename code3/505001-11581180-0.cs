            // t is a PdfPTable
            foreach(var row in t.Rows)
            {
                foreach(var cell in row.GetCells())
                {
                    if(cell.Phrase != null)
                    {
                        cell.Phrase.Font = fontNormal;
                    }
                }
            }

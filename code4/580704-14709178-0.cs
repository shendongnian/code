                foreach (var htmlElement in parsedHtmlElements)
                {
                    if (htmlElement is PdfPTable)
                    {
                        var table = (PdfPTable)htmlElement;
                        foreach (var row in table.Rows)
                        {
                            PdfPCell[] pdfCellTemp = row.GetCells();
                            if (pdfCellTemp.Length == 2)
                            {
                                float[] w = { 400, 100 };
                                row.SetWidths(w);
                            }
                        }
                    }
                    pdfCell.AddElement(htmlElement);
                }

     PdfDictionary pg = reader.GetPageN(1);
            PdfArray annotsArray = pg.GetAsArray(PdfName.ANNOTS);
            if (annotsArray != null)
            {
                for (int k = 0; k < annotsArray.Size; k++)
                {
                    PdfDictionary annot = (PdfDictionary) PdfReader.GetPdfObject(annotsArray[k]);
                    if(annot.GetAsName(PdfName.SUBTYPE).ToString() =="/Line")
                    {
                        annotsArray.Remove(k);
                    }
                }
            }

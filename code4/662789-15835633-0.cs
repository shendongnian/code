    PdfReader reader = new PdfReader("your.pdf");
    for (int i = 1; i <= reader.NumberOfPages; i++) {
        PdfArray array = reader.GetPageN(i).GetAsArray(PdfName.ANNOTS);
        if (array == null) continue;
        for (int j = 0; j < array.Size; j++) {
            PdfDictionary annot = array.GetAsDict(j);
            PdfString text = annot.GetAsString(PdfName.CONTENTS);
            ...
        }
    }

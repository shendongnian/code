    if (AnnotationDictionary.Contains(PdfName.FF)) {
        int Ff = AnnotationDictionary.GetAsNumber(PdfName.FF).IntValue;
        int doNotScrollBit = 0x800000;
        Ff = doNotScrollBit | Ff;
        AnnotationDictionary.Put(PdfName.FF, new PdfNumber(Ff));
    }

       protected int PaginaCampo(string campofirma, PdfDocument document)
    {
        for (int i = 0; i < document.Pages.Count; i++)
        {
            PdfAnnotations anotations = document.Pages[i].Annotations;
            for (int j = 0; j < anotations.Count; j++)
            {
                if (anotations[j].Title != campofirma) continue;
                return i;
            }
        }
        return -1;
    }

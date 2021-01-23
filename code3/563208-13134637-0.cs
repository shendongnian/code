    protected int FieldPage(string fieldname, PdfDocument document)
        {
            int refpage = -1;
            for (int i = 0; i < document.Pages.Count || refpage == -1; i++)
            {
                PdfAnnotations anotations = document.Pages[i].Annotations;
                for (int j = 0; j < anotations.Count; j++)
                {
                    if (anotations[j].Title != fieldname) continue;
                    refpage = i;
                    break;
                }
            }
        }

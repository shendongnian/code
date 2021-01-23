    private void LoadCommentList(string file) //using pdfsharp
        {
            PdfSharp.Pdf.PdfDocument inputDoc = PdfSharp.Pdf.IO.PdfReader.Open(file, PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
            PdfSharp.Pdf.PdfPage page = new PdfSharp.Pdf.PdfPage();
            for (int i = 0; i < inputDoc.PageCount; i++)
            {
                page = inputDoc.Pages[i];
                page = document.AddPage(page);
                for (int p = 0; p < document.Pages[i].Annotations.Elements.Count; p++)
                {
                    PdfAnnotation textAnnot = document.Pages[i].Annotations[p];
                    string content = textAnnot.Contents;
                    if (content != null)
                    {
                        CommentList.Add(content);
                    }
                }
            }
        }

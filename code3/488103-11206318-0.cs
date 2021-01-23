    ElementCollection elc = ie.Elements;
    System.Collections.Generic.List<Element> pdfList = new System.Collections.Generic.List<Element>();
    for (int i = 0; i < elc.Count; i++)
    {
        if(elc[i].Text.Contains("pdf"))
        {
            pdfList.Add(elc[i]);
        }
    }

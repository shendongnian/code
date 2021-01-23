    IEnumerable<Text> elems = wd.MainDocumentPart.Document.Body.Descendants<Text>();
    foreach (Text elem in elems) 
    {
        if(elem.InnerText.Equals("Ver 1"))
        {
            IEnumerable<OpenXmlElement> afterelems = elem.ElementsAfter();
            foreach(OpenXmlElement openelem in afterelems)
            {
                if(openelem is Text && ((Text)openelem).InnerText.Equals("Ver 2"))
                {
                    break;
                } else if(openelem is Text) {
                    openelem.Remove();
                }
            }
            break;
        }
    }
    foreach (Run run in wd.MainDocumentPart.Document.Body.Descendants<Run>().Where(run => run.Descendants<Text>().Count() == 0 && run.Descendants<Break>().Count() == 0))
    {
        run.Remove();
    }
    foreach (Paragraph par in wd.MainDocumentPart.Document.Body.Descendants<Paragraph>().Where(par => par.Descendants<Run>().Count() == 0 && par.Descendants<Table>().Count() == 0))
    {
        par.Remove();
    }

    foreach (Word.Section wordSection in currentDoc.Sections)
    {
        foreach (Word.HeaderFooter wordFooter in wordSection.Footers)
        {
            Word.Range docRange = wordFooter.Range; 
            
            docRange.Find.ClearFormatting();
            docRange.Find.Text = find;
            docRange.Find.Replacement.ClearFormatting();
            docRange.Find.Replacement.Text = replace;
            object replaceAll = Word.WdReplace.wdReplaceAll;
            docRange.Find.Execute(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                      Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                      ref replaceAll, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
    }

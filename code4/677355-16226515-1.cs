    public PdfOutline GetOutlineByCategory(Dictionary<string, PdfOutline> outlines, string category)
    {
        // This will be problematic if the category isn't actually in the dictionary.
        return outlines[category];
    }

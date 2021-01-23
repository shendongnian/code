    IMarkupPointer pBegin, pEnd;
    IMarkupServices markupServices;
    // ...
    pBegin.findText(word, 2, pEnd, null);
    IHTMLTxtRange range = htmlDocument2.selection.createRange();
    markupServices.MoveRangeToPointers(pBegin, pEnd, range);
    if(range.text != word)
    {
        // ...Text not found
    }

    if (unprocessedTextRenderInfos not empty)
    {
        if (isNewLine // Check this like the simple text extraction strategy checks for hardReturn
         || isGapFromPrevious) // Check this like the simple text extraction strategy checks whether to insert a space
        {
            process(unprocessedTextRenderInfos);
            unprocessedTextRenderInfos.clear();
        }
    }
    split new TextRenderInfo using its getCharacterRenderInfos() method;
    while (characterRenderInfos contain word end)
    {
        add characterRenderInfos up to excluding the white space/punctuation to unprocessedTextRenderInfos;
        process(unprocessedTextRenderInfos);
        unprocessedTextRenderInfos.clear();
        remove used render infos from characterRenderInfos;
    }
    add remaining characterRenderInfos to unprocessedTextRenderInfos;

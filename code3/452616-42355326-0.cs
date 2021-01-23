        /// <summary>
        /// Returns the position of the specified offset in the text specified by the inlines.
        /// </summary>
        /// <param name="inlines">The inlines which specifies the text.</param>
        /// <param name="offset">The offset within the text to get the position of.</param>
        /// <param name="contentStartPosition">The position where the content starts. If null, the position before the start of the first inline will be used. If null and there are no inlines, an exception is thrown.</param>
        /// <returns>A <see cref="TextPointer"/> indicating the position of the specified offset.</returns>
        public static TextPointer GetPositionAtOffset(this InlineCollection inlines, int offset, TextPointer contentStartPosition = null)
        {
            if (inlines == null)
                throw new ArgumentNullException(nameof(inlines));
            if (!inlines.Any() && contentStartPosition == null)//ha nincs inline, nincs miből megállapítani a tartalom kezdetét
                throw new ArgumentException("A content start position has to be specified if the inlines collection is empty.", nameof(contentStartPosition));
            if (contentStartPosition == null)
                contentStartPosition = inlines.First().ContentStart.DocumentStart;//kimenti a tartalom kezdetét, ha nem adta meg
            int offsetWithInlineBorders = 0;//ebbe menti az offset értéket (az inline-határokkal együtt)
            foreach (var inline in inlines)
            {
                int inlineLength = (inline as Run)?.Text.Length ?? (inline is LineBreak ? 1 : 0);//kimenti az inline hosszát (ha run, akkor a szöveg hosszát, a linebreak hossza 1, az egyéb típusokat pedig figyelmen kívül hagyja)
                if (inlineLength < offset)//ha a value által meghatározott pozíció az adott inline-on túl van...
                    offsetWithInlineBorders += inlineLength + 2;//...akkor az offsethez hozzáadja az inline teljes hosszát a két végével együtt
                else if (inlineLength == offset)//ha a value által meghatározott pozíció az adott inline vége...
                    offsetWithInlineBorders += inlineLength + 1;//...akkor az offsethez hozzáadja az inline teljes hosszát csak az első végével együtt
                else //inlineLength > value, ha a value által meghatározott pozíció az adott inline-on belül van...
                {
                    offsetWithInlineBorders += offset + 1;//...akkor az offsethez hozzáadja a hátramaradt hosszt (magát a value-t), plusz az adott inline első végét
                    break;//mivel a többi inline már biztosan a value által meghatározott pozíción túl lesz, abbahagyja az inline-ok hozzáadását
                }
                offset -= inlineLength;//levonja a most hozzáadott inline-hosszt
            }
            return contentStartPosition.GetPositionAtOffset(
                Math.Min(Math.Max(offsetWithInlineBorders, 0), contentStartPosition.GetOffsetToPosition(contentStartPosition.DocumentEnd)));//kimenti a textpositiont, túl nagy vagy túl kis értéknél pedig a szöveg elejét vagy végét veszi
        }

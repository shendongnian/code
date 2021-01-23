        private void _highlightTokens(FlowDocument document)
        {
            TextRange fullRange = new TextRange(document.ContentStart, document.ContentEnd);
            fullRange.ClearAllProperties(); // NOTICE: first remove allProperties.
            foreach (Token token in _tokenizer.GetTokens(fullRange.Text).Reverse()) // NOTICE: Reverse() to make the "right to left" work
            {
                TextPointer start = fullRange.Start.GetPositionAtOffset(token.Position);
                TextPointer end = start.GetPositionAtOffset(token.Length);
                TextRange range = new TextRange(start, end);
                range.ApplyPropertyValue(TextElement.ForegroundProperty, _getTokenColor(token));
            }
        }

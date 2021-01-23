        private void _highlightTokens(FlowDocument document)
        {
            TextRange fullRange = new TextRange(document.ContentStart, document.ContentEnd);
            foreach (Token token in _tokenizer.GetTokens(fullRange.Text))
            {
                TextPointer start = fullRange.Start.GetPositionAtOffset(token.Position);
                TextPointer end = start.GetPositionAtOffset(token.Length);
                TextRange range = new TextRange(start, end);
                range.ApplyPropertyValue(TextElement.ForegroundProperty, _getTokenColor(token));
            }
        }

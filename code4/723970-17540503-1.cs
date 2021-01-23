            TextRange tr = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
            tr.Text = text + "\r\n";           
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, solidColorBrush);
            if (limitLines > 0 && richTextBox.Document.Blocks.Count > limitLines)
            {
                for (int i = richTextBox.Document.Blocks.Count - limitLines; i < richTextBox.Document.Blocks.Count; i++)
                    richTextBox.Document.Blocks.Remove(richTextBox.Document.Blocks.FirstBlock);
            }

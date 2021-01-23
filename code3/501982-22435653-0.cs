     TextRange rangeText = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
     rangeText.Text = "Text1 ";
     rangeText.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Blue);
     rangeText.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
     TextRange rangeWord = new TextRange(richTextBox.Document.ContentEnd,        richTextBox.Document.ContentEnd);
     rangeWord.Text = "word ";
     rangeWord.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
     rangeWord.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Regular);
     TextRange rangeTextOne = new TextRange(richTextBox.Document.ContentEnd,     richTextBox.Document.ContentEnd);
     rangeTextOne.Text = "Text2 ";
     rangeTextOne.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Blue);
     rangeTextOne.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
      

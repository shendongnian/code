    private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {    
         tweetText.TextChanged -= RichTextBox_TextChanged;
         int pos = tweetText.CaretPosition.GetOffsetToPosition(tweetText.Document.ContentEnd);
         foreach (Paragraph line in tweetText.Document.Blocks.ToList())
         {
            string text = new TextRange(line.ContentStart,line.ContentEnd).Text;
            
            line.Inlines.Clear();
            string[] wordSplit = text.Split(new char[] { ' ' });
            int count = 1;
            foreach (string word in wordSplit)
            {
                if (word.StartsWith("@"))
                {
                    Run run = new Run(word);
                    run.FontWeight = FontWeights.Bold;
                    line.Inlines.Add(run);
                }
                else
                {
                    line.Inlines.Add(word);
                }
                if (count++ != wordSplit.Length)
                {
                     line.Inlines.Add(" ");
                }
            }
         }
         tweetText.CaretPosition = tweetText.Document.ContentEnd.GetPositionAtOffset(-pos);
         tweetText.TextChanged += RichTextBox_TextChanged;
    }

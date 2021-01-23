    private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        tweetText.TextChanged -= RichTextBox_TextChanged;
    
        foreach (Paragraph line in tweetText.Document.Blocks.ToList())
        {
            string text = new TextRange(line.ContentStart,
                           line.ContentEnd).Text;
    
            line.Inlines.Clear();
    
            string[] wordSplit = text.Split(new char[] { ' ' });
    
            foreach (string word in wordSplit)
            {
                if (word.StartsWith("@"))
                {
                    line.Inlines.Add(new Bold(new Run(word + " ")));
                }
                else
                {
                    line.Inlines.Add(new Run(word + " "));
                }
            }
        }
        tweetText.CaretPosition = tweetText.CaretPosition.DocumentEnd;
        tweetText.CaretPosition.DeleteTextInRun(-1);
        tweetText.TextChanged += RichTextBox_TextChanged;
    }

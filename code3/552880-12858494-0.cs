    Paragraph para = new Paragraph {
        Foreground = Brushes.Red,
    };
    para.Inlines.Add(new Bold(new Run(matchingString)));
    para.Inlines.Add(new Run(regularText));
    myRichTextBox.Document.Blocks.Add(para);

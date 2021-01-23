        TextSelection ts = rtb.Selection;
        TextPointer start = ts.Start;
        TextPointer end = ts.End;
        TextRange before = new TextRange(rtb.Document.ContentStart, start);
        TextRange after = new TextRange(end, rtb.Document.ContentEnd);
        TextRange linker = new TextRange(start, end);
        Paragraph myParagraph = new Paragraph();
        myParagraph.Inlines.Clear();
        myParagraph.Inlines.Add(before.Text);
        Hyperlink hyperLink = new Hyperlink();
        hyperLink.Inlines.Add(ts.Text);
        hyperLink.Click += new RoutedEventHandler(hyperLink_Click);
        myParagraph.Inlines.Add(hyperLink);
        myParagraph.Inlines.Add(after.Text);
        rtb.Document.Blocks.Clear();
        
        rtb.Document.Blocks.Add(myParagraph);

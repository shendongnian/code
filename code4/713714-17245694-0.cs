    var rtb = new RichTextBlock();
    var paragraph = new Paragraph();
    paragraph.Inlines.Add(new Run { Text = "Hello" });
    paragraph.Inlines.Add(new InlineUIContainer { Child = new Button { Content = "World" } });
    rtb.Blocks.Add(paragraph);
    ((Grid)this.Content).Children.Add(rtb);

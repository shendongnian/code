    // close out paragraph and move to next line
    textBlock.Inlines.Add(new LineBreak());
    var span = new Span();
    // use a smaller size so there's less of a gap to the next paragraph
    span.FontSize = 4;
    // super awful hack. Using a space here won't work, but tab does
    span.Inlines.Add(new Run("\t"));
    // now the height of this line break will be governed by the font size we set above, not by the font size of the main text
    span.Inlines.Add(new LineBreak());
    textBlock.Inlines.Add(span);

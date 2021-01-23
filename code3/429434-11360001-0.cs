    Paragraph p1 = document.Paragraphs.Add(System.Reflection.Missing.Value);
    p1.Range.Text = "Foo";
    p1.Range.InsertParagraphAfter();
    
    // Add new paragraph relative to first paragraph
    Paragraph p2 = document.Paragraphs.Add(p1.Range);
    p2.Range.Text = "Bar";
    p2.Range.InsertParagraphAfter();
    
    // Add new paragraph relative to the second paragraph
    Paragraph p3 = document.Paragraphs.Add(p2.Range);
    p3.Range.Text = "Baz";

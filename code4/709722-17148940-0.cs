    //Paths to our font files
    var arial_regular_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
    var arial_italic_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ariali.ttf");
    
    //Create base fonts
    var arial_regular_base = BaseFont.CreateFont(arial_regular_path, BaseFont.IDENTITY_H, false);
    var arial_italic_base = BaseFont.CreateFont(arial_italic_path, BaseFont.IDENTITY_H, false);
    
    //Create sized-fonts using the bases above
    var arial_regular = new iTextSharp.text.Font(arial_regular_base, 12);
    var arial_italic = new iTextSharp.text.Font(arial_italic_base, 12);
    
    //Test paragraph
    var p = new Paragraph();
    p.Add(new Chunk("This is a test using an ", arial_regular));
    p.Add(new Chunk("italic", arial_italic));
    p.Add(new Chunk(" font", arial_regular));
    
    doc.Add(p);

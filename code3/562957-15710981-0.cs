    //Create a ColumnText from the current writer
    var ct = new ColumnText(writer.DirectContent);
    //Set the dimensions of the ColumnText
    ct.SetSimpleColumn(0, 0, 500, 0 + 20);
    //Create two fonts
    var helv_n = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
    var helv_b = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
    //Create a paragraph
    var p = new Paragraph();
    //Add two chunks to the paragraph with different fonts 
    p.Add(new Chunk("Hello ", new iTextSharp.text.Font(helv_n, 12)));
    p.Add(new Chunk("World", new iTextSharp.text.Font(helv_b, 12)));
    //Add the paragraph to the ColumnText
    ct.AddElement(p);
    //Tell the ColumnText to draw itself
    ct.Go();

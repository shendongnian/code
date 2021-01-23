    string textBlock = @"
    Mr. Petersen
    Elmstreet 9
    888 Fantastic City  
    ".Trim();
    // get the longest line to calcuate the container width  
    var widest = textBlock.Split(
        new string[] {Environment.NewLine}
        , StringSplitOptions.None
      )
      .Aggregate(
        "", (x, y) => x.Length > y.Length ? x : y
      )
    ;
    // throw-away Chunk; used to set the width of the PdfPCell containing
    // the aligned text block
    float w = new Chunk(widest).GetWidthPoint();
    PdfPTable t = new PdfPTable(2);
    float pageWidth = document.PageSize.Width 
      - document.LeftMargin 
      - document.RightMargin
    ;
    t.SetTotalWidth(new float[]{ pageWidth - w, w });
    t.LockedWidth = true;  
    t.DefaultCell.Padding = 0;
    // you can add text in the left PdfPCell if needed
    t.AddCell("");
    t.AddCell(textBlock);
    document.Add(t);

    private static Doc AddHeader(Doc theDoc)
    {
        int theCount = theDoc.PageCount;
        int i = 0;
    
        //Image header 
        for (i = 1; i <= theCount; i++)
        {
             theDoc.Rect.Width = 590;
             theDoc.Rect.Height = 140;
             theDoc.Rect.Position(0, 706);
    
             theDoc.PageNumber = i;
             string imagefilePath = HttpContext.Current.Server.MapPath("/images/pdf/pdf-header.png");
    
             Bitmap myBmp = (Bitmap)Bitmap.FromFile(imagefilePath);
             theDoc.AddImage(myBmp);
         }
    
         //Blue header box
         for (i = 2; i <= theCount; i++)
         {
             theDoc.Rect.String = "20 15 590 50";
             theDoc.Rect.Position(13, 672);
             System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#468DCB");
             theDoc.Color.Color = c;
             theDoc.PageNumber = i;
             theDoc.FillRect();
         }
    
         //Blue header text
         for (i = 2; i <= theCount; i++)
         {
             theDoc.Rect.String = "20 15 586 50";
             theDoc.Rect.Position(25, 660);
             System.Drawing.Color cText = System.Drawing.ColorTranslator.FromHtml("#ffffff");
             theDoc.Color.Color = cText;
             string theFont = "Century Gothic";
             theDoc.Font = theDoc.AddFont(theFont);
             theDoc.FontSize = 14;
             theDoc.PageNumber = i;
             theDoc.AddText("Your Text Here");
         }
         return theDoc;
    }

        private static Doc AddFooter(Doc theDoc)
        {
            int theCount = theDoc.PageCount;
            int i = 0;
            for (i = 1; i <= theCount; i++)
            {
                theDoc.Rect.String = "20 15 590 50";
                theDoc.Rect.Position(13, 30);
                System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#468DCB");
                theDoc.Color.Color = c;
                theDoc.PageNumber = i;
                theDoc.FillRect();
            }
            i = 0;
            for (i = 1; i <= theCount; i++)
            {
                theDoc.Rect.String = "20 15 260 50";
                theDoc.Rect.Position(190, 20);
                System.Drawing.Color cText = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                theDoc.Color.Color = cText;
                string theFont = "Century Gothic";
                theDoc.Font = theDoc.AddFont(theFont);
                theDoc.FontSize = 17;
                theDoc.PageNumber = i;
                theDoc.AddText("Page " + i +" of " +theCount); //Setting page number  
                //theDoc.FrameRect();
            }
            return theDoc;
        }

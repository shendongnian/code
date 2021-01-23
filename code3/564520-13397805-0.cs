                //Setting to create the document using ABCPdf 8
    
                var theDoc = new Doc();
    
                theDoc.MediaBox.String = "A4";
    
                theDoc.HtmlOptions.PageCacheEnabled = false;
                theDoc.HtmlOptions.ImageQuality = 101;
                theDoc.Rect.Width = 719;
                theDoc.Rect.Height = 590;
                theDoc.Rect.Position(2, 70);
                theDoc.HtmlOptions.Engine = EngineType.Gecko;

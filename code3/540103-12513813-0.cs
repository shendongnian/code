     IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                        IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
     string imagename = string.Empty;
     try
     {
     foreach (IHTMLImgElement img in doc.images)
       {
         imgRange.add((IHTMLControlElement)img);
         imgRange.execCommand("Copy", false, null);
         using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
            {
                bmp.Save(@"c:\testImage\TestPic.jpg");
            }
         imagename = img.nameProp;
         break;
       }
     }
     catch (System.Exception aaa)
     {
         
     }

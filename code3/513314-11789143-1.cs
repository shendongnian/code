    public Image DownloadImageFromURL(string url)
    {
       HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(filename);
       httpWebRequest.AllowWriteStreamBuffering = true;            
       httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";            
       httpWebRequest.Timeout = 30000; //30 seconds
       webResponse = httpWebRequest.GetResponse();    
       webStream = webResponse.GetResponseStream();
       Image downloadImage = Image.FromStream(webStream);            
       webResponse.Close();   
       return downloadImage;
    }
    //in your code
        using (var pdfDoc = new Document()) 
    using (var pdfWriter = PdfWriter.GetInstance(pdfDoc, pdfStream)) { 
        pdfDoc.Open();
        Image tif = DownloadImageFromURL("www.myimage.com");
        pdfDoc.Add(tif);
        pdfDoc.Close();
    }

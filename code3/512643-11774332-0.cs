      public static Attachment GetPDfAttachmentFromUrl(string url)
            {
                string download = new WebClient().DownloadString(url);
    
                MemoryStream ms = new MemoryStream();
                Document document = new Document(PageSize.A4, 80, 50, 30, 65);
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                try
                {
                    StringReader stringReader = new StringReader(download);
                    List<IElement> parsedList = HTMLWorker.ParseToList(stringReader, null);
                    document.Open();
                    foreach (object item in parsedList)
                    {
                        document.Add((IElement)item);
                    }
                    document.Close();
                    stringReader.Close();
    
                    MemoryStream pdfstream = new MemoryStream(ms.ToArray());
    //create attachment
                    Attachment attachment = new Attachment(pdfstream, "transaction.pdf");
                    
                    return attachment;
                }
                catch (Exception exc)
                {
                    Console.Error.WriteLine(exc.Message);
                }
                return null;
            }

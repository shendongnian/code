    static Stream GetPipedStream(Action<Stream> writeAction) 
    { 
        AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(); 
        ThreadPool.QueueUserWorkItem(s => 
        { 
            using (pipeServer) 
            { 
                writeAction(pipeServer); 
                pipeServer.WaitForPipeDrain(); 
            } 
        }); 
        return new AnonymousPipeClientStream(pipeServer.GetClientHandleAsString()); 
    } 
    public FileStreamResult DownloadPDF() 
    {
        var readable = 
            GetPipedStream(output => { 
                using(var zip = new ZipFile()) 
                {
                    foreach(Bla bla in Blas) 
                    { 
                        zip.AddEntry(bla.filename + ".pdf", (name,stream) => {
                            var thisBla = GetBlaFromName(name);
                            Document document = new Document(); 
                            PdfWriter.GetInstance(document, stream).CloseStream = false; 
                            document.Open(); 
                            // write PDF Content for thisBla to PdfWriter
                            document.Close(); 
                        });
                    } 
                    zip.Save(output); 
                }
            }); 
        var fileResult = new FileStreamResult(readable, System.Net.Mime.MediaTypeNames.Application.Zip); 
        fileResult.FileDownloadName = "MultiplePDFs.zip"; 
        return fileResult; 
    }

               PdfWriter writer = PdfWriter.GetInstance(document, msOutput);
                document.Open();
                HTMLWorker worker = new HTMLWorker(document);
    
                Dictionary<string, object> providers = new Dictionary<string, object>();
                //Get url of the application
                string url = "http://www.url.com/" //url from which images are loaded
                //Bind image providers for the application
                providers.Add(HTMLWorker.IMG_BASEURL, url);
                //Bind the providers to the worker
                worker.SetProviders(providers);
    
                document.Open();
                worker.StartDocument();
    
                // Parse the html into the document
                
                worker.Parse(reader);
                worker.EndDocument();
                worker.Close();
                document.Close();

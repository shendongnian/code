    HttpWebRequest req = WebRequest.Create("http://url.to/file.xml") as HttpWebRequest;
    
    // check if the cast went well
    if (req != null) {
        try {
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            System.IO.FileStream outFileStream = System.IO.File.Create(@"Path\To\localfile.xml");
            
            resp.GetResponseStream().CopyTo(outFileStream);
            
            outFileStream.Close();
            outFileStream.Dispose();
        }
        catch { 
            // Catch all specific exceptions... ommitted here for brevity 
        }
    }

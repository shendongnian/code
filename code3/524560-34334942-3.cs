    HttpResponseMessage result = null;
    result = Request.CreateResponse(HttpStatusCode.OK);
    FileStream stream = File.OpenRead(path);
    byte[] fileBytes = new byte[stream.Length];
    stream.Read(fileBytes, 0, fileBytes.Length);
    stream.Close();           
    result.Content = new ByteArrayContent(fileBytes);
    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
    result.Content.Headers.ContentDisposition.FileName = "FileName.pdf";            

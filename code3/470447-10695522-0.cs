    using (var response = S3.GetObject(request))
    {
        using (var responseStream = response.ResponseStream)
        {
            context.Response.ContentType = "image/jpeg";
    
            var buffer = new byte[8000];
            int bytesRead = -1;
            while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, bytesRead);
            }
        }
    }
    context.Response.End();

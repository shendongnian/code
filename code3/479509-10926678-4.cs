    public class CacheAsset
    {
       public string FileName { get; set; }
       public string ContentType { get; set; }
       public byte[] Content { get; set; }
    }
    
    CacheAsset GetAsset(HttpContext context)
    {
       string courseKey = context.Request.QueryString["ck"];
       string objKey = context.Request.QueryString["file"];
    
       var asset = context.Cache[objKey] as CacheAsset;
    
       if (asset != null) return asset;
    
       using (var response = Gets3Response(objKey, courseKey, context))
       using (var stream = new MemoryStream())
       { 
          var buffer = new byte[8000];
          var read = 0;
        
          while ((read = response.ReponseStream.Read(buffer, 0, buffer.Length) > 0)
          {
             stream.Write(buffer, 0, read);
          }
    
          asset = new CacheAsset
                  {
                     FileName = objKey,
                     ContentType = reponse.ContentType,
                     Content = stream.ToArray()
                  };
           context.Cache.Insert(objKey, response.ResponseStream, null, DateTime.UtcNow.AddMinutes(20), Cache.NoSlidingExpiration);
       }
    
       return asset;
    }
    
    void WriteAsset(HttpContext context)
    {
       var asset = GetAsset(context);
    
       context.Response.ContentType = asset.ContentType;
       context.Response.BinaryWrite(asset.Content);
    }

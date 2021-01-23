       public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
       {
          if (CanWriteType(type) && mediaType.MediaType == supportedMediaType)
          {
             headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
             headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
             headers.ContentDisposition.FileName = "ebook.mobi";
          }
          else
          {
             base.SetDefaultContentHeaders(type, headers, mediaType);
          }
       }

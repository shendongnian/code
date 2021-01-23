    public FileContentResult ShowPhoto(int id)
        {
           TemporaryImageUpload tempImageUpload = new TemporaryImageUpload();
           tempImageUpload = _service.GetImageData(id) ?? null;
           if (tempImageUpload != null)
           {
              byte[] byteArray = tempImageUpload.TempImageData;
              using(var outStream = new MemoryStream()){
                  using(var inStream = new MemoryStream(byteArray)){
                      var settings = new ResizeSettings("maxwidth=200&maxheight=200");
                      ImageResizer.ImageBuilder.Current.Build(inStream, outStream, settings);
                      var outBytes = outStream.ToArray();
                      return new FileContentResult (outBytes, "image/jpeg");
                  }
              }
           }
           return null;
        }

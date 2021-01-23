    private byte[] _rawImage;
    public byte[] RawImage
    {
         get { return _rawImage; }
         set 
         {
                 _rawImage = value;
                 if (_rawImage == null)
                         return;
    
                 var bitmap = BitmapFactory.DecodeByteArray(_rawImage, 0,_rawImage.Length);
                 SetImageBitmap(bitmap);
         }
    }

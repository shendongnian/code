    public class ItemViewModel 
    {
       private BitmapImage _image;
       public BitmapImage Image 
       {
          get{
    
          if(_image == null)
          {
             _image = new BitmapImage();
              StartDownloadImageAsync();
          }
           return _image;
          }
       }
    }

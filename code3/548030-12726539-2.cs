    public class ImageProvider()
    {
    public event EventHandler LiveImageUpdated;
    private object _currentImageLock = new object();
    
    private Bitmap _currentImage;
    public Bitmap CurrentImage
    { 
        get    
          {
           lock (_currentImageLock)
             {
                return DeepImageCopy(_currentImage)
             }
           }
         private set
         {
           lock(_currentImageLock)
           {
                _currentImage = value
           }
            if (LiveImageUpdated != null)
            {
              foreach (Delegate del in LiveImageUpdated.GetInvocationList())
              {
                  EventHandler handler = (EventHandler)del;
                  handler.BeginInvoke(this, EventArgs.Empty, null, null);
               }
            }
         }
    }
        

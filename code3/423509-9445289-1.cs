    public class MultipleIconsViewModel
    {
        private BitmapImage _icon;
        public ImageSource Icon
        {
            get
            {
                if (_icon == null)
                {
                    _icon = new BitmapImage(new Uri(@"..\images\myImage.png", UriKind.RelativeOrAbsolute));
                    // can't call Freeze() until DownloadCompleted event fires.
                    _icon.DownloadCompleted += (sender, args) => ((BitmapImage) sender).Freeze();
                }
                return _icon;
            }
        }
    }
 

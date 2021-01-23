    public class SafePicture : System.Windows.Controls.ContentControl
    {
        public SafePicture()
        {
            this.Unloaded += this.SafePictureUnloaded;
        }
        private void SafePictureUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var image = this.Content as System.Windows.Controls.Image;
            if (image != null)
            {
                image.Source = null;
            }
        }
    }

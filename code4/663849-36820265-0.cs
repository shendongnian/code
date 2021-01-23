    PhotoChooserTask selectphoto;
    private void selectImageFromMediaLib()
    {
       selectphoto = new PhotoChooserTask();
       selectphoto.Completed += new EventHandler<PhotoResult>(selectphoto_Completed);
       selectphoto.Show();
    }
    private void selectphoto_Completed(object sender, PhotoResult e)
    {
       if (e.TaskResult == TaskResult.OK)
       {
           var imageBytes = new byte[e.ChosenPhoto.Length];
           e.ChosenPhoto.Read(imageBytes, 0, imageBytes.Length);
           BitmapImage bitmapImage = new BitmapImage();
           MemoryStream ms = new MemoryStream(imageBytes);
           bitmapImage.SetSource(ms);
           ImageBrush imageBrush = new ImageBrush();
           imageBrush.ImageSource = bitmapImage;
           this.LayoutRoot.Background = imageBrush;
        }
    }

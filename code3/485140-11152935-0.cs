    namespace TakePicture
    {
        public partial class MainPage : PhoneApplicationPage
        {
            CameraCaptureTask camera = new CameraCaptureTask();
            PhotoChooserTask choosephoto = new PhotoChooserTask();
    
            public MainPage()
            {
                InitializeComponent();
                camera.Completed += new EventHandler<PhotoResult>(task_Completed);
                choosephoto.Completed += new EventHandler<PhotoResult>(task_Completed);
            }
    
            private void btntakephoto_Click(object sender, RoutedEventArgs e)
            {
                camera.Show();
            }
    
            private void btnchoosephoto_Click(object sender, RoutedEventArgs e)
            {
                choosephoto.Show();
            }
    
            private string SaveImageToLocalStorage(WriteableBitmap image, string imageFileName)
            {
    
                if (image == null)
                {
                    throw new ArgumentNullException("imageBytes");
                }
                try
                {
                    var isoFile = IsolatedStorageFile.GetUserStoreForApplication();
    
                    if (!isoFile.DirectoryExists("MyPhotos"))
                    {
                        isoFile.CreateDirectory("MyPhotos");
                    }
    
                    string filePath = System.IO.Path.Combine("/" + "MyPhotos" + "/", imageFileName);
                    using (var stream = isoFile.CreateFile(filePath))
                    {
                         image.SaveJpeg(stream, image.PixelWidth, image.PixelHeight, 0, 80);
                    }
    
                    return new Uri(filePath, UriKind.Relative).ToString();
                }
                catch (Exception)
                {
                    //TODO: log or do something else
                    throw;
                }
            }
    
            void task_Completed(object sender, PhotoResult e)
            {
                if (e.ChosenPhoto != null)
                {
                    if (e.TaskResult == TaskResult.OK)
                    {
                        try
                        {
                           string imagePathOrContent = string.Empty;
                           WriteableBitmap image = PictureDecoder.DecodeJpeg(e.ChosenPhoto);
                           imgphoto.Source = image;
                           imagePathOrContent = this.SaveImageToLocalStorage(image, System.IO.Path.GetFileName(e.OriginalFileName));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
    }

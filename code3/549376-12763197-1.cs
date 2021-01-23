    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {            
            // Call this directly:
            // var images = LoadImages();
            // Images = images;
            
            // or bind the Command property of Button to the LoadImagesCommand.
            LoadImagesCommand = new RelayCommand(() => 
                {
                    var images = LoadImages();
                    Images = images;
                });
        }
        
        public ObservableCollection<ImageViewModel> Images { get; private set; }
        public ImageViewModel SelectedImage { get; set; }
        
        public ICommand LoadImagesCommand { get; private set; }
        
        private List<ImageViewModel> LoadImages()
        {
            List<ImageViewModel> images = new List<ImageViewModel>();
            
            // Part of the original code.
            foreach (string fileName in fileStorage.GetFileNames("images//*.*"))
            {
                if (fileName == null)
                    break;
                string filepath = System.IO.Path.Combine("images", fileName);
                using (IsolatedStorageFileStream imageStream = fileStorage.OpenFile(filepath,FileMode.Open,FileAccess.Read))
                {
                    var imageSource = PictureDecoder.DecodeJpeg(imageStream);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(imageStream);
                    
                    ImageViewModel imageViewModel = new ImageViewModel(fileName, bitmapImage);
                    images.Add(imageViewModel);
                }
            }
        }
    }
    

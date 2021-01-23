    public class MainPageViewModel : Screen
    {
        public MainPageViewModel()
        {
            MyPhoto = new BitmapImage(new Uri("ms-appx:///Assets/SplashScreen.png"));
        }
        public ImageSource MyPhoto { get; set; }
        public ImageBrush MyBrush
        {
            get
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = MyPhoto;
                return brush;
            }
        }
    }

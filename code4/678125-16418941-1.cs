      public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            PanoramaItem panItem = new PanoramaItem();
            List<ImageList> imgList = new List<ImageList>();
                     
            
            imgList.Add(new ImageList() { ImageName = ImagePath.Image4 });
            lbImages.ItemsSource = imgList;
        }
        public class ImageList
        {
            public string ImageName { get; set; }
        }
    }

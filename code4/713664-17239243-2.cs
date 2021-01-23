    public class SlideShowViewModel:PropertyChangedBase
    {
        public const string SourceURL = "http://lorempixel.com/400/200/sports/";
        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }
        private System.Threading.Timer _slideShowTimer;
        private System.Random _random = new Random();
        public SlideShowViewModel()
        {
            _slideShowTimer = new Timer(x => OnTimerTick(), null, 1000, 3000);
        }
        private void OnTimerTick()
        {
            ImageSource = SourceURL + _random.Next(1, 10).ToString();
        }
    }

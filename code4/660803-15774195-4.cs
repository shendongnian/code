    public partial class MovingWords : Window
    {
        public ObservableCollection<MovingWordModel> Words { get; set; }
        public MovingWords()
        {
            InitializeComponent();
            Words = new ObservableCollection<MovingWordModel>
                {
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "Hello!!"},
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "This"},
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "is"},
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "the"},
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "Power"},
                    new MovingWordModel() {Color = "Black", FontSize = 18, Text = "of"},
                    new MovingWordModel() {Color = "Blue", FontSize = 18, Text = "WPF"},
                };
            DataContext = Words;
        }
        private void Thumb_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb == null)
                return;
            var word = thumb.DataContext as MovingWordModel;
            
            if (word == null)
                return;
            word.OffsetX += e.HorizontalChange;
            word.OffsetY += e.VerticalChange;
        }
    }

    public partial class MainPage : PhoneApplicationPage {
        public class SelectedPhoto : IDisposable {
            public Stream Data { get; private set; }
            public string Name { get; private set; }
            public BitmapImage Image { get; private set; }
            public SelectedPhoto(string name, Stream photo) {
                Name = name;
                Data = new MemoryStream();
                photo.CopyTo(Data);
                Image = new BitmapImage();
                Image.SetSource(Data);
            }
            public void Dispose() {
                Data.Dispose();
            }
        }
        private List<SelectedPhoto> _selectedPhotos = new List<SelectedPhoto>();
        private PhotoChooserTask photoChoserTask;
        // Constructor
        public MainPage() {
            InitializeComponent();
            photoChoserTask = new PhotoChooserTask();
            photoChoserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            ProcessImages.IsEnabled = false;
            ImageListBox.ItemsSource = _selectedPhotos
        }
        void photoChooserTask_Completed(object sender, PhotoResult e) {
            if (e.TaskResult == TaskResult.OK) {
                _selectedPhotos.Add(new SelectedPhoto(e.OriginalFileName, e.ChosenPhoto);
                Button.IsEnabled = _selectedPhotos.Count < 9;
                ProcessImages.IsEnabled = _selectedPhotos.Count == 9;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            {
                try {
                    photoChoserTask.Show();
                } catch (System.InvalidOperationException) {
                    MessageBox.Show("An error occurred.");
                }
            }
        }
        private void ProcessImages_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Doing something with your images... please wait...");
        }
    }

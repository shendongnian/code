    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            var of = new OpenFileDialog();
            of.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            var res = of.ShowDialog();
            if (res.HasValue)
            {
                imgPreview.Source = new BitmapImage(new Uri(of.FileName));
                var t = Utils.ConvertBitmapSourceToByteArray(imgPreview.Source as BitmapSource);
                var d = Utils.ConvertBitmapSourceToByteArray(new BitmapImage(new Uri(of.FileName)));
                var s = Utils.ConvertBitmapSourceToByteArray(imgPreview.Source);
                var enc = Utils.ConvertBitmapSourceToByteArray(new PngBitmapEncoder(), imgPreview.Source);
                //imgPreview2.Source = Utils.ConvertByteArrayToBitmapImage(enc);
                imgPreview2.Source = Utils.ConvertByteArrayToBitmapImage2(enc);
                //var i = 0;
            }
            else
            {
                MessageBox.Show("Select a currect file...");
            }
        }
    }

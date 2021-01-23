    public MainPage()
        {
        InitializeComponent();
            photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            }
            private void photochooserbtn_Click(object sender, RoutedEventArgs e)
             {
             photoChooserTask.Show();
             }
            void photoChooserTask_Completed(object sender, PhotoResult e)
             {
             if (e.TaskResult == TaskResult.OK)
             {
             System.Windows.Media.Imaging.BitmapImage bmp =new     System.Windows.Media.Imaging.BitmapImage();
             bmp.SetSource(e.ChosenPhoto);
             imagecontrol.Source = bmp;
             }
           }

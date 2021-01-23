    namespace YouTube
    {
        using System;
        using System.ComponentModel;
        using System.Windows;
        using Google.GData.Client;
        using Google.GData.Extensions.MediaRss;
        using Google.GData.YouTube;
        using Google.YouTube;
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private static BackgroundWorker uploader;
            private static YouTubeRequestSettings settings;
            static void UploaderDoWork(object sender, DoWorkEventArgs e)
            {
                var request = new YouTubeRequest(settings);
                var newVideo = new Video { Title = "Test" };
                newVideo.Tags.Add(new MediaCategory("Animals", YouTubeNameTable.CategorySchema));
                newVideo.Description = "Testing Testing Testing";
                newVideo.YouTubeEntry.Private = true;
                newVideo.YouTubeEntry.MediaSource = new MediaFileSource("C:\\Wildlife.wmv", "video/x-ms-wmv");            
                try
                {
                    request.Upload(newVideo);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Upload failed: " + exception.Message);
                }
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                settings = new YouTubeRequestSettings(
                    "app",
                    "devkey",
                    "email",
                    "password");
                uploader = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
                uploader.DoWork += UploaderDoWork;
                uploader.RunWorkerCompleted += delegate { MessageBox.Show("Upload completed!"); };
                uploader.RunWorkerAsync();
                MessageBox.Show("Initiated upload...");
            }
        }
    }

    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Tasks;
    namespace WP7Photo
    {
        public partial class MainPage : PhoneApplicationPage
        {
            public class IsoImageWrapper
            {
                public string Uri { get; set; }
                public ImageSource Source
                {
                    get
                    {
                        IsolatedStorageFile isostore = IsolatedStorageFile.GetUserStoreForApplication();
                        var bmi = new BitmapImage();
                        bmi.SetSource(isostore.OpenFile(Uri, FileMode.Open, FileAccess.Read));
                        return bmi;
                    }
                }
            }
            public ObservableCollection<IsoImageWrapper> Images { get; set; }
            // Constructor
            public MainPage()
            {
                InitializeComponent();
                Images = new ObservableCollection<IsoImageWrapper>();
                listBox1.ItemsSource = Images;
            }
            private void Button1Click(object sender, RoutedEventArgs e)
            {
                var cameraTask = new CameraCaptureTask();
                cameraTask.Completed += new EventHandler<PhotoResult>(cameraTask_Completed);
                cameraTask.Show();
            }
            void cameraTask_Completed(object sender, PhotoResult e)
            {
                if (e.TaskResult != TaskResult.OK)
                {
                    return;
                }
                StorePhoto(e);
            }
            private void StorePhoto(PhotoResult photo)
            {
                IsolatedStorageFile isostore = IsolatedStorageFile.GetUserStoreForApplication();
                if (!isostore.DirectoryExists("photos"))
                {
                    isostore.CreateDirectory("photos");
                }
                var filename = "photos/"  + System.IO.Path.GetFileName(photo.OriginalFileName);
                if (isostore.FileExists(filename)) { isostore.DeleteFile(filename);}
                using (var isoStream = isostore.CreateFile(filename))
                {
                    photo.ChosenPhoto.CopyTo(isoStream);
                }
                Images.Add(new IsoImageWrapper {Uri = filename});
            }
        }
    }

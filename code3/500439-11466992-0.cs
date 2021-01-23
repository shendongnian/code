    using System;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Media;
    
    namespace delWpf
    {
        public partial class MainWindow : Window
        {
            private string fileName = @"Q:\grass.jpg";
    
            public MainWindow()
            {
                InitializeComponent();
                var image = System.Drawing.Image.FromFile(fileName);
                surfaceButton.Background = new ImageBrush(GetBitmapSource(image));
            }
    
            private System.Windows.Media.Imaging.BitmapSource GetBitmapSource(System.Drawing.Image image)
            {
                var bitmap=new Bitmap(image);
                
                System.Windows.Media.Imaging.BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bitmap.GetHbitmap(),
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                return bitmapSource;
            }
        }
    }

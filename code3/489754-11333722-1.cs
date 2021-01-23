    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Navigation;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Interop;
    using System.Windows.Media.Animation;
    using System.Threading;
    namespace wpf_TestVideos
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string VideoLocation = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        string sFileName = "";
        string sFileName2 = "";
        bool bVideoLoop = true;
        TranslateTransform trans = new TranslateTransform();
        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            mediaElement15sec.LoadedBehavior = MediaState.Manual;
            mediaElement3sec.LoadedBehavior = MediaState.Manual;
            btGesture.IsEnabled = true;
            btStart.IsEnabled = true;
            btLoad.IsEnabled = false;
            DirectoryInfo df = new DirectoryInfo(VideoLocation);
            if (df.Exists)
            {
                sFileName = VideoLocation + @"\Krown_test_loop.mov";
                mediaElement15sec.Source = new Uri(sFileName);
                mediaElement15sec.Stretch = Stretch.Fill;
                sFileName2 = VideoLocation + @"\Krown_test_7.mov";
                mediaElement3sec.Source = new Uri(sFileName2);
                mediaElement3sec.Stretch = Stretch.Fill; 
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No se puede cargar el video", "TestAll");
            }
        }
        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            mediaElement15sec.Position = TimeSpan.Zero;
            mediaElement3sec.Position = TimeSpan.Zero;
            mediaElement15sec.Play();
            mediaElement3sec.Play();
            bVideoLoop = true;
            //VisualStateManager.GoToState(mediaElement15sec, "Bring1,5ToFront", true);
        }
        private void mediaElement15sec_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (bVideoLoop)
            {
                mediaElement15sec.Position = TimeSpan.Zero;
                mediaElement3sec.Position = TimeSpan.Zero;
            }
        }
        private void btGesture_Click(object sender, RoutedEventArgs e)
        {
            bVideoLoop = false;
            //Animacion_Opacidad(bVideoLoop);
            //VisualStateManager.GoToState(mediaElement3sec, "Bring300ToFront", true);
        }
        private void Animacion_Opacidad(bool bLoop)
        {
            mediaElement15sec.RenderTransform = trans;
            if (!bLoop)
            {
                DoubleAnimation anim1 = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
                trans.BeginAnimation(OpacityProperty, anim1);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btGesture.IsEnabled = false;
            btStart.IsEnabled = false;
            btLoad.IsEnabled = true;
        }
    }
}

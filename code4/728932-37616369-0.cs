    using System.Drawing;
    namespace DDD
    {
        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
            public App()
            {
                nIcon.Icon = new Icon(@"path to ico");
                nIcon.Visible = true;
                nIcon.ShowBalloonTip(5000, "Title", "Text",  System.Windows.Forms.ToolTipIcon.Info);
                nIcon.Click += nIcon_Click;
            }
            void nIcon_Click(object sender, EventArgs e)
            {
                //events comes here
                MainWindow.Visibility = Visibility.Visible;
                MainWindow.WindowState = WindowState.Normal;
            }
        }
    }

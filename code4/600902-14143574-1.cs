    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                System.Windows.Forms.PictureBox picturebox1 = new System.Windows.Forms.PictureBox();
                windowsFormsHost1.Child = picturebox1;
                picturebox1.Paint += new System.Windows.Forms.PaintEventHandler(picturebox1_Paint);
            }
            void picturebox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            {
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"C:\Temp\test.jpg");
                System.Drawing.Point ulPoint = new System.Drawing.Point(0, 0);
                e.Graphics.DrawImage(bmp,ulPoint);
            }
        }
    }

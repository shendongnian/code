    namespace ScreenCapture0
    {
        public partial class ScreenCapture0 : Form
        {
    
            string path1;
    
    
            public ScreenCapture0()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Point curPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                Size curSize = new Size();
                curSize.Height = Cursor.Current.Size.Height; curSize.Width = Cursor.Current.Size.Width;
                path1 = @"C:\Documents and Settings\Admin\My Documents\Visual Studio 2010\Projects\ScreenCapture0\ScreenCapture0\bin\Debug\000.bmp";
                System.Threading.Thread.Sleep(250);
                Rectangle r1 = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                string fi = new FileInfo(path1).Extension;
                Bitmap b1 = new Bitmap(r1.Width, r1.Height);
                Graphics g1 = Graphics.FromImage(b1);
                g1.CopyFromScreen(Point.Empty, Point.Empty, r1.Size);
                Rectangle r2 = new Rectangle(curPos, curSize);
                Cursors.Default.Draw(g1, r2);
                b1.Save(path1, ImageFormat.Bmp);
            }
    
    
        }
    }

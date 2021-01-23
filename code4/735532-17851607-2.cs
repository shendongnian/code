        [STAThread()]
        static void Main(string[] args)
        {
            Image img = Clipboard.GetImage();
            img.Save(@"c:\temp\myimg.png",System.Drawing.Imaging.ImageFormat.Png);
        }

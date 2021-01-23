    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    class Program
    {
        static void Main(string[] args)
        {
            var source =  @"
            <!DOCTYPE html>
            <html>
                <body>
                    <p>An image from W3Schools:</p>
                    <img 
                        src=""http://www.w3schools.com/images/w3schools_green.jpg"" 
                        alt=""W3Schools.com"" 
                        width=""104"" 
                        height=""142"">
                </body>
            </html>";
            StartBrowser(source);
            Console.ReadLine();
        }
        private static void StartBrowser(string source)
        {
            var th = new Thread(() =>
            {
                var webBrowser = new WebBrowser();
                webBrowser.ScrollBarsEnabled = false;
                webBrowser.DocumentCompleted +=
                    webBrowser_DocumentCompleted;
                webBrowser.DocumentText = source;
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        static void 
            webBrowser_DocumentCompleted(
            object sender, 
            WebBrowserDocumentCompletedEventArgs e)
        {
            var webBrowser = (WebBrowser)sender;
            using (Bitmap bitmap = 
                new Bitmap(
                    webBrowser.Width, 
                    webBrowser.Height))
            {
                webBrowser
                    .DrawToBitmap(
                    bitmap, 
                    new System.Drawing
                        .Rectangle(0, 0, bitmap.Width, bitmap.Height));
                bitmap.Save(@"filename.jpg", 
                    System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }

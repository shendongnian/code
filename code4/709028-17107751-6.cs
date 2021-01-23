    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    
    namespace WebApplication1
    {
        public partial class ChartCtl : System.Web.UI.UserControl
        {
            private int imageHeight = 150;
            private int imageWidth = 400;
            
            public MemoryStream renderChart(MemoryStream ms)
            {
                Image imgChart = new Bitmap(imageWidth, imageHeight);
                Graphics g = Graphics.FromImage(imgChart);
                Rectangle r = new Rectangle(0, 0, imageWidth, imageHeight);
                g.DrawEllipse(Pens.SteelBlue, g.VisibleClipBounds);
                imgChart.Save(ms, ImageFormat.Jpeg);                    // save the image to the memorystream to be processed via the Image/HttpHandler
                imgChart.Save(Context.Response.OutputStream, ImageFormat.Jpeg);    // save to drive just to verify that image is being properly created.
                return ms;
            }
        }
    }

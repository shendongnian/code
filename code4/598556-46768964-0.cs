    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing.Printing;
    
    namespace Cls_PanelPrinting
    {
        public class Print
        {
            readonly PrintDocument printdoc1 = new PrintDocument();
            readonly PrintPreviewDialog previewdlg = new PrintPreviewDialog();
            public int page = 1;
            internal string tempPath { get; set; }
            private int pageIndex = 0;
            internal List<Image> list { get; set; }
            private int _Line = 0;
    
    
            private readonly Panel panel_;
    
            public Print(Panel pnl)
            {
                panel_ = pnl;
                printdoc1.PrintPage += (printdoc1_PrintPage);
                PrintDoc();
            }
    
    
            private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
            {
                Font myFont = new Font("Cambria", 10, FontStyle.Italic, GraphicsUnit.Point);
    
                float lineHeight = myFont.GetHeight(e.Graphics) + 4;
    
                float yLineTop = 1000;
    
               
    
                int x = e.MarginBounds.Left;
                int y = 25; //e.MarginBounds.Top;
                e.Graphics.DrawImageUnscaled(list[pageIndex],
                                            x,y);
               
    
                pageIndex++;
                e.HasMorePages = (pageIndex < list.Count);
    
                e.Graphics.DrawString("Page No: " + pageIndex, myFont, Brushes.Black,
                     new PointF(e.MarginBounds.Right, yLineTop));
              
            }
    
            public void PrintDoc()
            {
            
                try
                {
    
                    Panel grd = panel_;
                    Bitmap bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
                    grd.DrawToBitmap(bmp, new Rectangle(0, 0, grd.Width, grd.Height));
    
                    Image objImage = (Image)bmp;
    
                    Bitmap objBitmap = new Bitmap(objImage, new Size(700, objImage.Height));
    
                    Image PrintImage = (Image)objBitmap;
    
                    list = new List<Image>();
                    Graphics g = Graphics.FromImage(PrintImage);
                    Brush redBrush = new SolidBrush(Color.Red);
                    Pen pen = new Pen(redBrush, 3);
                    decimal xdivider = panel_.Width / 595m;
                    // int xdiv = Convert.ToInt32(Math.Ceiling(xdivider));
                    decimal ydivider = panel_.Height / 900m;
                    int ydiv = Convert.ToInt32(Math.Ceiling(ydivider));
    
    
    
                    int xdiv = panel_.Width / 595; //This is the xsize in pt (A4)
    
                    for (int i = 0; i < xdiv; i++)
                    {
                        for (int y = 0; y < ydiv; y++)
                        {
                            Rectangle r;
                            if (panel_.Height > 900)
                            {
    
                                try
                                {
                                    if (list.Count > 0)
                                    {
                                        r = new Rectangle(0, (900 * list.Count), PrintImage.Width, PrintImage.Height - (900 * list.Count));
                                    }
                                    else
                                    {
                                        r = new Rectangle(0, 0, PrintImage.Width, 900);
                                    }
                                    list.Add(cropImage(PrintImage, r));
                                }
    
                                catch (Exception)
                                {
    
                                    list.Add(PrintImage);
                                }
                            }
                            else { list.Add(PrintImage); }
                           
                        }
                    }
    
                    g.Dispose();
    
                    PrintImage = list[0];
    
                   
                    PrintDocument printDocument = new PrintDocument();
                    printDocument.PrintPage += printdoc1_PrintPage;
                    PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                    previewDialog.Document = printDocument;
                    pageIndex = 0;
    
                    printDocument.DefaultPageSettings.PrinterSettings.PrintToFile = true;
    
                    string path = "d:\\BillIng.xps";
                    if (File.Exists(path))
                        File.Delete(path);
    
                    printDocument.DefaultPageSettings.PrinterSettings.PrintFileName = "d:\\BillIng.xps";
                    printDocument.PrintController = new StandardPrintController();
                 
    
                    printDocument.Print();
    
    
                    printDocument.PrintPage -= printdoc1_PrintPage;
                }
    
                catch { }
    
            }
            private static Image cropImage(Image img, Rectangle cropArea)
            {
                Bitmap bmpImage = new Bitmap(img);
                Bitmap bmpCrop = bmpImage.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
                return (Image)(bmpCrop);
            }
    
        }
    }

    private void printImage_Btn_Click(object sender, EventArgs e)
        {
            list = new List<Image>();
            Graphics g = Graphics.FromImage(image_PctrBx.Image);
            Brush redBrush = new SolidBrush(Color.Red);
            Pen pen = new Pen(redBrush, 3);
           decimal xdivider = image_PctrBx.Image.Width / 595m;
            int xdiv = Convert.ToInt32(Math.Ceiling(xdivider));
            decimal ydivider = image_PctrBx.Image.Height / 841m;
            int ydiv = Convert.ToInt32(Math.Ceiling(ydivider));
            /*int xdiv = image_PctrBx.Image.Width / 595; //This is the xsize in pt (A4)
            int ydiv = image_PctrBx.Image.Height / 841; //This is the ysize in pt (A4)
            // @ 72 dots-per-inch - taken from Adobe Illustrator
            if (xdiv >= 1 && ydiv >= 1)
            {*/
                for (int i = 0; i < xdiv; i++)
                {
                    for (int y = 0; y < ydiv; y++)
                    {
                        Rectangle r;
                        try
                        {
                            r = new Rectangle(i * Convert.ToInt32(image_PctrBx.Image.Width / xdiv),
                                                        y * Convert.ToInt32(image_PctrBx.Image.Height / ydiv),
                                                        image_PctrBx.Image.Width / xdiv,
                                                        image_PctrBx.Image.Height / ydiv);
                        }
                        catch (Exception)
                        {
                            r = new Rectangle(i * Convert.ToInt32(image_PctrBx.Image.Width / xdiv),
                              y * Convert.ToInt32(image_PctrBx.Image.Height),
                              image_PctrBx.Image.Width / xdiv,
                              image_PctrBx.Image.Height);
                        }
                        g.DrawRectangle(pen, r);
                        list.Add(cropImage(image_PctrBx.Image, r));
                    }
                }
            g.Dispose();
            image_PctrBx.Invalidate();
            image_PctrBx.Image = list[0];
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            pageIndex = 0;
            previewDialog.ShowDialog();
            // don't forget to detach the event handler when you are done
            printDocument.PrintPage -= PrintDocument_PrintPage;
        }

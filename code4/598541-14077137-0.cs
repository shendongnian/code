    private void printImage_Btn_Click(object sender, EventArgs e)
        {
            list = new List<Image>();
            Graphics g = Graphics.FromImage(image_PctrBx.Image);
            Brush redBrush = new SolidBrush(Color.Red);
            Pen pen = new Pen(redBrush, 3);
            MessageBox.Show(image_PctrBx.Image.Width + " " + image_PctrBx.Image.Height);
            int xdivider = image_PctrBx.Image.Width / 595; //This is the xsize in pt (A4)
            int ydivider = image_PctrBx.Image.Height / 841; //This is the ysize in pt (A4)
            // @ 72 dots-per-inch - taken from Adobe Illustrator
            if (xdivider > 1 || ydivider > 1)
            {
                for (int i = 0; i < xdivider; i++)
                {
                    for (int y = 0; y < xdivider; y++)
                    {
                        Rectangle r = new Rectangle(i * (image_PctrBx.Image.Width / xdivider),
                                                    y * (image_PctrBx.Image.Height / ydivider),
                                                    image_PctrBx.Image.Width / xdivider,
                                                    image_PctrBx.Image.Height / ydivider);
                        g.DrawRectangle(pen, r);
                        list.Add(cropImage(image_PctrBx.Image, r));
                    }
                }
            }
            else
            {
                Rectangle r = new Rectangle(0, 0, image_PctrBx.Image.Width, image_PctrBx.Image.Height);             
                g.DrawRectangle(pen, r);
                list.Add(cropImage(image_PctrBx.Image, r));
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

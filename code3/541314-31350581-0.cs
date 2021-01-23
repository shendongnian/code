    Bitmap bitmapToPrint;
        public void printImage()
        {
            bitmapToPrint = new Bitmap(3400,4400);
            Font font = new Font(FontFamily.GenericSansSerif, 120, FontStyle.Regular);
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Graphics graphics = Graphics.FromImage(bitmapToPrint);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            graphics.DrawString(alphabet, font, System.Drawing.Brushes.Black, 0, 0);
            graphics.DrawString(alphabet, font, System.Drawing.Brushes.Black, 0, 1000);
            graphics.DrawString(alphabet, font, System.Drawing.Brushes.Black, 0, 2000);
            graphics.DrawString(alphabet, font, System.Drawing.Brushes.Black, 0, 3000);
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmapToPrint, new RectangleF(0.0f, 0.0f, 850.0f, 1100.0f));
        }
